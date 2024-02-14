/* Source:
 * 1 - AISC Design Guide 01 - Base Plate And Anchor Rod Design 2nd Ed - 2014
 *
 *
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Base_Plate_Engine.Common.Mathematics;
using Base_Plate_Engine.Common.Section.Shapes;
using EngineeringUnits;
using Mojk.HTML;
using Mojk.HTML.Elements;
using Mojk.HTML.Extensions;
using MojStruct.Concrete.ACI.ACI318_19.C10_Columns;
using MojStruct.Concrete.ACI.ACI318_19.C19_Concrete;
using MojStruct.Concrete.ACI.Entities.Rebar;

namespace Base_Plate_Engine.Design
{
    public sealed class ColumnBase
    {
	    private HtmlDocument document;

		private double mm { get; set; }
        private double nn { get; set; }
       
        private double Alpha1(double a, double b)
        {
            const double TOLERANCE = 0.00001;
            double[] Alpha1X = { 1, 1.1, 1.2, 1.4, 1.5, 1.6, 1.8, 1.9, 2 };
            double[] Alpha1Y = { 0.048, 0.055, 0.063, 0.075, 0.081, 0.086, 0.094, 0.098, 0.132, 0.1 };
            
            if (a / b < Alpha1X[0])
            {
                return Alpha1Y[0];
            }

            for (var i = 0; i < Alpha1X.Length; i++)
            {
                if (Math.Abs(a / b - Alpha1X[i]) < TOLERANCE)
                {
                    return Alpha1Y[i];
                }
            }

            for (var i = 0; i < Alpha1X.Length - 1; i++)
            {
                if (a / b > Alpha1X[i] && a / b < Alpha1X[i + 1])
                {
                    return (Alpha1Y[i + 1] - Alpha1Y[i]) / (Alpha1X[i + 1] - Alpha1X[i]) * (a / b - Alpha1X[i]) + Alpha1Y[i];
                }
            }

            return Alpha1Y[Alpha1Y.Length - 1];
        }

        private double Alpha2(double c, double d)
        {
            const double TOLERANCE = 0.00001;
            double[] Alpha2X = { 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.2, 1.4, 2 };
            double[] Alpha2Y = { 0.06, 0.074, 0.088, 0.097, 0.107, 0.112, 0.12, 0.126, 0.132, 0.133 };

            if (c / d < Alpha2X[0])
            {
                return Alpha2Y[0];
            }

            for (var i = 0; i < Alpha2X.Length; i++)
            {
                if (Math.Abs(c / d - Alpha2X[i]) < TOLERANCE)
                {
                    return Alpha2Y[i];
                }
            }

            for (var i = 0; i < Alpha2X.Length - 1; i++)
            {
                if (c / d > Alpha2X[i] && c / d < Alpha2X[i + 1])
                {
                    return (Alpha2Y[i + 1] - Alpha2Y[i]) / (Alpha2X[i + 1] - Alpha2X[i]) * (c / d - Alpha2X[i]) + Alpha2Y[i];
                }
            }

            return Alpha2Y[Alpha2Y.Length - 1];
        }

        public int Design(BasePlateInput basePlateInput, IList<BasePlateLoad> loadsList, out DesignResult[] designResults, out HtmlDocument report)
        {
	        document = new HtmlDocument("");

			document.AddRawHeading($"<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">");
			document.AddRawHeading($"<script type=\"text/javascript\" id=\"MathJax-script\" async src=\"https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-mml-chtml.js\"></script>");

			document.AddClass("body", new Dictionary<string, string>()
			{
				{"font-size", "12px"},
			});

			document.AddClass(".formula > div", new Dictionary<string, string>()
			{
				{ "margin", "auto 0" }
			});
			document.AddClass(".formula > div:last-child", new Dictionary<string, string>()
			{
				{ "text-align", "right!important" },
			});
			document.AddClass(".h1", new KeyValuePair<string, string>("color", "red"));

			var results = new DesignResult[loadsList.Count];
            
            mm = (basePlateInput.N - 0.95 * basePlateInput.Sec.h) / 2;
            nn = (basePlateInput.B - 0.8 * basePlateInput.Sec.bf) / 2;

            document.AddFormula(@$"m = \frac{{ N - 0.95 h }}{{2}} = {mm:F1} \: mm", "", "");
            document.AddFormula(@$"n = \frac{{ B - 0.80 b_f }}{{2}} = {nn:F1} \: mm", "", "");

			for (var i = 0; i < loadsList.Count; i++)
            {
                document.AddElement(new Heading4($"Load: {loadsList[i].Name}"));

                if (loadsList[i].IsWithoutMoment)
                {
                    results[i] = Design_PV(basePlateInput, loadsList[i].Pu, loadsList[i].Vux);
                }
                else if (loadsList[i].Pu > 0 && loadsList[i].Muy > 0)
                {
                    results[i] = Design_Moment(basePlateInput, loadsList[i].Pu, loadsList[i].Vux, loadsList[i].Muy);
                }
                else if (loadsList[i].Pu <= 0 && loadsList[i].Muy > 0)
                {
                    results[i] = Design_Moment(basePlateInput, loadsList[i].Pu, loadsList[i].Vux, loadsList[i].Muy);
                }

                results[i].WeldRatio_BP = Design_Weld(basePlateInput, loadsList[i].Pu, loadsList[i].Vux);
                results[i].WeldRatio_SK = 0;
            }
            
            var concreteMaterial = new ConcreteMaterial(basePlateInput.fc);
            var rebarMaterial = new RebarMaterialGeneral(basePlateInput.fyr, 1.5 * basePlateInput.fyr);
            var transverseRebarMaterial = new RebarMaterialGeneral(basePlateInput.fyrs, 1.5 * basePlateInput.fyrs);

            var concreteColumn = new RectangularConcreteColumn(basePlateInput.Np, basePlateInput.Bp, basePlateInput.nrN, basePlateInput.nrB, basePlateInput.dr, basePlateInput.Cover, concreteMaterial, rebarMaterial);

            var loads = loadsList
                .Select(t => new P_M_Load(
                    t.Pu,
                    t.Muy + basePlateInput.Hp * t.Vux))
                .ToList();

            var flexuralResultsX = concreteColumn.CalculateFlexuralBendingRatio(Direction.X, loads);
            var flexuralResultsY = concreteColumn.CalculateFlexuralBendingRatio(Direction.Y, loads);

            var axialLoad = loadsList
                .Select(t => t.Pu)
                .ToList();

            var shearLoad = loadsList
                .Select(t => t.Vux)
                .ToList();

            var A_v = basePlateInput.nrS * (Math.PI * Math.Pow(basePlateInput.drs, 2) / 4);


            var ratio = new double[loadsList.Count];
            for (var i = 0; i < loadsList.Count; i++)
            {
                ratio[i] = concreteColumn.CalculateShearStrengthAlongX(loadsList[i].Vux, loadsList[i].Pu, A_v, basePlateInput.rsS, transverseRebarMaterial, out _, out var warnings);
            }
            
            for (var i = 0; i < flexuralResultsX.Count; i++)
            {
                results[i].PedestalRatio = Math.Min(flexuralResultsX[i], flexuralResultsY[i]);
                results[i].PedestalShearRatio = ratio[i];
            }
            
            designResults = results;

            CheckAnchorBolts(basePlateInput);

            report = document;

			return 0;
        }

        public DesignResult Design(BasePlateInput basePlateInput, BasePlateLoad basePlateLoadList)
        {
            var designResult = new DesignResult();

            mm = (basePlateInput.N - 0.95 * basePlateInput.Sec.h) / 2;
            nn = (basePlateInput.B - 0.8 * basePlateInput.Sec.bf) / 2;


            if (basePlateLoadList.IsWithoutMoment)
            {
                designResult = Design_PV(basePlateInput, basePlateLoadList.Pu, basePlateLoadList.Vux);
            }
            else if (basePlateLoadList.Pu > 0 && basePlateLoadList.Muy > 0)
            {
                designResult = Design_Moment(basePlateInput, basePlateLoadList.Pu, basePlateLoadList.Vux, basePlateLoadList.Muy);
            }
            else if (basePlateLoadList.Pu <= 0 && basePlateLoadList.Muy > 0)
            {
                designResult = Design_Moment(basePlateInput, basePlateLoadList.Pu, basePlateLoadList.Vux, basePlateLoadList.Muy);
            }

            designResult.WeldRatio_BP = Design_Weld(basePlateInput, basePlateLoadList.Pu, basePlateLoadList.Vux);
            designResult.WeldRatio_SK = 0;
            
            var A_v = basePlateInput.nrS * (Math.PI * Math.Pow(basePlateInput.drs, 2) / 4);

            var concreteMaterial = new ConcreteMaterial(basePlateInput.fc);
            var rebarMaterial = new RebarMaterialGeneral(basePlateInput.fyr, 1.5 * basePlateInput.fyr);
            var transverseRebarMaterial = new RebarMaterialGeneral(basePlateInput.fyrs, 1.5 * basePlateInput.fyrs);

            var concreteColumn = new RectangularConcreteColumn(basePlateInput.Np, basePlateInput.Bp, basePlateInput.nrN, basePlateInput.nrB, basePlateInput.dr, basePlateInput.Cover, concreteMaterial, rebarMaterial);

            var loads = new List<P_M_Load>()
            {
                new P_M_Load(
                    basePlateLoadList.Pu,
                    basePlateLoadList.Muy + basePlateInput.Hp * basePlateLoadList.Vux)
            };

            var flexuralResultsX = concreteColumn.CalculateFlexuralBendingRatio(Direction.X, loads);
            var flexuralResultsY = concreteColumn.CalculateFlexuralBendingRatio(Direction.Y, loads);


            var ratio = concreteColumn.CalculateShearStrengthAlongX(basePlateLoadList.Vux, basePlateLoadList.Pu, A_v, basePlateInput.rsS, transverseRebarMaterial, out _, out _);

            for (var i = 0; i < flexuralResultsX.Count; i++)
            {
                designResult.PedestalRatio = Math.Min(flexuralResultsX[i], flexuralResultsY[i]);
                designResult.PedestalShearRatio = ratio;
            }

            return designResult;
        }


        private double Design_Weld(BasePlateInput basePlateInput, double Pu, double Vux)
        {
            var V = Math.Sqrt(Math.Pow(Pu, 2) + Math.Pow(Vux, 2));

            if (basePlateInput.WeldType == WeldType.Fillet)
            {
                return (V / basePlateInput.Sec.Perimeter) / basePlateInput.Fnw_BP;
            }

            return 0;
        }

        private DesignResult Design_TV1(BasePlateInput basePlateInput, double Pu, double Vux)
        {
            var ret = new DesignResult();
            var f = basePlateInput.N / 2 - basePlateInput.a_N;
            var T_rod = -Pu / basePlateInput.nb;
            var Tu = T_rod * basePlateInput.nbN;

            var x = Math.Abs(f - basePlateInput.Sec.h / 2 + basePlateInput.Sec.tf / 2);
            var t1 = Math.Sqrt(4 * Tu * x / (basePlateInput.Phi * basePlateInput.B * basePlateInput.fyp));

            var ratio = GetBoltRatio(basePlateInput, -Pu, Vux, basePlateInput.nb);

                ret.t = t1;
                ret.BoltRatio = ratio.Item1;
                ret.ShearKeyRatio = ratio.Item2;
                ret.Succeed = true;

            return ret;
        }

        private DesignResult Design_PV(BasePlateInput basePlateInput, double Pu, double Vu)
        {
            const double TOLERANCE = 0.0001;
            var ret = new DesignResult();
            double fup = 0;

            if (Pu > 0)
            {
                fup = Pu / (basePlateInput.N * basePlateInput.B);

                document.AddFormula(@$"f_{{up}} = \frac{{ P_u }}{{ N \times B }} = {fup:F2} \: MPa");

                ret.fup = fup;
                ret.BearingRatio = fup / basePlateInput.Fp_max;

                if (fup > basePlateInput.Fp_max)
                {
                    ret.DesignMessage.Add("Increase base plate dimensions!!");
                    ret.Succeed = false;
                    return ret;
                }
            }
            else
            {
                ret.fup = 0;
                ret.BearingRatio = fup / basePlateInput.Fp_max;
            }

            var ratio = Pu >= 0
                ? GetBoltRatio(basePlateInput, 0, Vu, basePlateInput.nb)
                : GetBoltRatio(basePlateInput, -Pu, Vu, basePlateInput.nb);

            ret.BoltRatio = ratio.Item1;
            ret.ShearKeyRatio = ratio.Item2;

            if (Math.Abs(Pu) < TOLERANCE)
            {
                ret.Tu = 0;
                ret.t = 0;
                ret.ts = 0;
                ret.Succeed = true;
                return ret;
            }

            if (Pu > 0)
            {
                Design_Compression_PlateThickness(basePlateInput, Pu, basePlateInput.StiffnerType, ref ret);
            }
            else
            {
                Design_Tension_PlateThickness(basePlateInput, Pu, basePlateInput.StiffnerType, ref ret);
            }

            return ret;
        }

        private int Design_Compression_PlateThickness(BasePlateInput input, double Pu, int stiffenerType, ref DesignResult ret)
        {
            double t1;
            double Mul;

            double Alpha1Func(double a, double b)
            {
                return MyMath.Interpolate(a / b,
                    new[] { 1, 1.1, 1.2, 1.4, 1.5, 1.6, 1.8, 1.9, 2 , 2.0001},
                    new[] { 0.048, 0.055, 0.063, 0.075, 0.081, 0.086, 0.094, 0.098, 0.132, 0.1 });
            }

            double Alpha2Func(double c, double d)
            {
                return MyMath.Interpolate(c / d,
                    new[] { 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.2, 1.4, 2, 2.0001 },
                    new[] { 0.06, 0.074, 0.088, 0.097, 0.107, 0.112, 0.12, 0.126, 0.132, 0.133 });
            }

            switch (stiffenerType)
            {
                case 0:
                    var x = 4 * input.Sec.h * input.Sec.bf / Math.Pow((input.Sec.h + input.Sec.bf), 2) * Pu / (input.Phi_c * input.Pp);
                    var lambda = Math.Min(2 * Math.Sqrt(x) / (1 + Math.Sqrt(1 - x)), 1);
                    var lambdaN1 = lambda * Math.Sqrt(input.Sec.h * input.Sec.bf) / 4;

                    Mul = ret.fup * Math.Pow(MyMath.Max(mm, nn, lambdaN1), 2) / 2;
                    t1 = Math.Sqrt(4 * Mul / (input.Phi * input.fyp));


                    ret.Ml = Mul;
                    ret.Tu = 0;
                    ret.t = t1;
                    ret.ts = 0;

                    ret.Succeed = true;
                    return 0;
                case 1:
                    var s_c = new double[2];
                    var s_d = new double[2];
                    double s_a = input.Sec.h - input.Sec.tf;
                    double s_b = input.Sec.bf / 2;

                    s_c[0] = (input.B - input.Sec.bf) / 2;
                    s_d[0] = input.Sec.h - input.Sec.tf;

                    s_c[1] = (input.N - input.Sec.h) / 2;
                    s_d[1] = input.Sec.bf;

                    var s_f1 = (input.B - input.Sec.bf) / 2;
                    var s_f2 = (input.N - input.Sec.h) / 2;

                    var s_e = s_f1 * s_f2 / (3 * Math.Sqrt(Math.Pow(s_f1, 2) + Math.Pow(s_f2, 2)));

                    var mm1 = Alpha1Func(s_a, s_b) * Math.Pow(s_b, 2);
                    var mm2 = Alpha2Func(s_c[0], s_d[0]) * Math.Pow(s_c[0], 2);
                    var mm3 = Alpha2Func(s_c[1], s_d[1]) * Math.Pow(s_c[1], 2);

                    var mm4 = s_f1 * s_f2 / 2 * s_e / Math.Sqrt(Math.Pow(s_f1, 2) + Math.Pow(s_f2, 2));

                    Mul = ret.fup * MyMath.Max(mm1, mm2, mm3, mm4);
                    t1 = Math.Sqrt(4 * Mul / (input.Phi * input.fyp));

                    var MaN = ret.fup * Math.Pow(mm, 2) / 2 * input.N;
                    var MaB = ret.fup * Math.Pow(nn, 2) / 2 * input.B;

                    var ts1 = 1 / Math.Pow(input.hs, 2) * ((MaN / input.Phi) / input.fyp - input.N * Math.Pow(t1, 2) / 2);
                    var ts2 = input.hs / (1.03 * Math.Sqrt(input.Es / input.fyp));

                    var ts3 = 1 / Math.Pow(input.hs, 2) * ((MaB / input.Phi) / input.fyp - input.B * Math.Pow(t1, 2) / 2);
                    var ts4 = input.hs / (1.03 * Math.Sqrt(input.Es / input.fyp));

                    ret.Ml = Mul;
                    ret.Tu = 0;
                    ret.t = t1;
                    ret.ts = MyMath.Max(ts1, ts2, ts3, ts4);
                    ret.Succeed = true;
                    return 0;
            }

            return 0;
        }

        private int Design_Tension_PlateThickness(BasePlateInput basePlateInput, double Pu, int stiffenerType, ref DesignResult ret)
        {
            if (stiffenerType == 0)
            {
                var f1 = basePlateInput.N / 2 - basePlateInput.a_N;
                var f2 = basePlateInput.B / 2 - basePlateInput.a_B;

                var T_rod = -Pu / basePlateInput.nb;
                var TuN = T_rod * basePlateInput.nbN;
                var TuB = T_rod * basePlateInput.nbB;

                var x1 = Math.Abs(f1 - basePlateInput.Sec.h / 2 + basePlateInput.Sec.tf / 2);
                var x2 = Math.Abs(f2 - basePlateInput.Sec.bf / 2);

                var mul1 = TuN * x1;
                var mul2 = TuB * x2;

                var t1 = Math.Sqrt(4 * mul1 / (basePlateInput.Phi * basePlateInput.B * basePlateInput.fyp));
                var t2 = Math.Sqrt(4 * mul2 / (basePlateInput.Phi * basePlateInput.B * basePlateInput.fyp));

                ret.Ml = Math.Max(mul1, mul2);

                ret.Tu = -Pu;
                ret.t = Math.Max(t1, t2);
                ret.ts = 0;
                ret.Succeed = true;
            }
            else if (stiffenerType == 1)
            {
                var mul1 = 0.0;
                var mul2 = 0.0;

                var B1 = (basePlateInput.N - basePlateInput.Sec.h) / 2;
                var B2 = (basePlateInput.B - basePlateInput.Sec.bf) / 2;

                var e1 = B1 - basePlateInput.a_N;
                var e2 = B2 - basePlateInput.a_B;
                e1 = e1 >= B1 / 2
                    ? e1 - B1 / 2
                    : 0;

                e2 = e2 >= B2 / 2
                    ? e2 - B2 / 2
                    : 0;

                var eB = Math.Max(e1 / B1, e2 / B2);
                var fact1 = 1 + eB;
                var fact2 = (basePlateInput.N * basePlateInput.B) / (basePlateInput.N * basePlateInput.B - basePlateInput.Sec.h * basePlateInput.Sec.bf);
                var Pu_Comp = -Pu * fact1 * fact2;

                var ret1 = new DesignResult
                {
                    fup = Pu_Comp / (basePlateInput.N * basePlateInput.B)
                };

                Design_Compression_PlateThickness(basePlateInput, Pu_Comp, stiffenerType, ref ret1);

                ret.Ml = Math.Max(mul1, mul2);              //need to be fixed

                ret.Tu = -Pu;
                ret.t = ret1.t;
                ret.ts = 0;
                ret.Succeed = true;
            }

            return 0;
        }

        private DesignResult Design_Moment(BasePlateInput basePlateInput, double Pu, double Vux, double Muy)
        {
            var ret = new DesignResult();
            switch (basePlateInput.AnalysisType)
            {
                case PressureDistribution.Rectangular:
                    ret = Design_Moment_Rectangle(basePlateInput, Pu, Vux, Muy);
                    ret = basePlateInput.StiffnerType == 0
                        ? Design_Moment_Rectangle(basePlateInput, Pu, Vux, Muy)
                        : Design_Moment_Rectangle_WithStiffener(basePlateInput, Pu, Vux, Muy);
                    break;
                case PressureDistribution.Triangular:
                    ret = Design_Moment_Triangle(basePlateInput, Pu, Vux, Muy);
                    break;
                default:
                    ret.Succeed = false;
                    break;
            }
            return ret;
        }

        //private int Design_Moment_Rectangle(
        //    double N, double B, double a_N, Sections_IWideFlnage Sec,
        //    double Phi, double Phi_c, double fc, double fyp, double A2, double A1, double Fp_max,
        //    double Pu, double Vux, double Muy, 
        //    out double fup, out double boltRatio, out double bearingRatio, out double shearKeyRatio, out double Tu, out double t, out IList<string> errors)
        //{
        //    //AISC Steel Design Guide: Base Plate and Anchor Rod Design, Second Edition: Section 4.6
        //    //Units kg-mm

        //    errors = new List<string>();

        //    Muy = Math.Abs(Muy);

        //    var e = Pu == 0.0
        //        ? double.Epsilon
        //        : Math.Abs(Muy / Pu);

        //    var e1 = a_N;

        //    var fp_max = Phi_c * (0.85 * fc) * Math.Min(Math.Sqrt(A2 / A1), 2.0);
        //    var q_max = fp_max * B;
        //    var e_crit = N / 2 - Pu / (2 * q_max);

        //    double t1;
        //    double Y;
        //    if (e <= e_crit)      //Small Moment
        //    {
        //        Y = N - 2 * e;

        //        var q = Pu / Y;
        //        if (q > q_max)
        //        {
        //            throw new Exception();
        //        }

        //        var m = (N - 0.95 * Sec.h) / 2.0;
                
        //        fup = Math.Max(Pu / (B * Y), 0);

        //        bearingRatio = fup / Fp_max;
        //        if (fup > Fp_max)
        //        {
        //            errors.Add("Increase base plate dimensions!!");
        //            ///return 1;
        //        }

        //        //Eq. 3.3.14a-1 & 3.3.14b-1
        //        t1 = Y >= mm
        //            ? Math.Sqrt(4 * fup * Math.Pow(mm, 2) / 2 / (Phi * fyp))        //LRFD
        //            : Math.Sqrt(4 * fup * Y * (mm - Y / 2) / (Phi * fyp));          //ASD

        //        Tu = 0;
        //        t = t1;
        //        boltRatio = 0;
        //    }
        //    else if (e > e_crit)       //Large Moment
        //    {
        //        double T_rod = 0;
        //        var f = N / 2 - a_N;

        //        double Y1;
        //        double Y2;
        //        if (Pu > 0)
        //        {
        //            Y1 = (f + N / 2) + Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Pu * (e + f) / (Fp_max * B));
        //            Y2 = (f + N / 2) - Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Pu * (e + f) / (Fp_max * B));
        //        }
        //        else if (Pu < 0)
        //        {
        //            e = Math.Abs(e);
        //            Y1 = (f + N / 2) + Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Pu * (f - e) / (Fp_max * B));
        //            Y2 = (f + N / 2) - Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Pu * (f - e) / (Fp_max * B));
        //        }
        //        else// if (Pu == 0)
        //        {
        //            Y1 = (f + N / 2) + Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Muy / (Fp_max * B));
        //            Y2 = (f + N / 2) - Math.Sqrt(Math.Pow((f + N / 2), 2) - 2 * Muy / (Fp_max * B));
        //        }

        //        if (double.IsNaN(Y1) && double.IsNaN(Y2))
        //        {
        //            errors.Add("Increase base plate dimensions!!");
        //            //return 1;
        //        }

        //        Y = MyMath.Min(Y1, Y2);
        //        if (Y <= 0)
        //        {
        //            throw new Exception();
        //        }
                
        //        fup = Math.Max(Pu / (B * Y), 0);
        //        bearingRatio = fup / Fp_max;
        //        if (fup > Fp_max)
        //        {
        //            errors.Add("Increase base plate dimensions!!");
        //            //return 2;
        //        }

        //        // For Tension
        //        //Eq. 3.3.14a-1 & 3.3.14b-1
        //        t1 = Y >= mm
        //            ? Math.Sqrt(4 * Fp_max * Math.Pow(mm, 2) / 2 / (Phi * fyp))
        //            : Math.Sqrt(4 * Fp_max * Y * (mm - Y / 2) / (Phi * fyp));
        //        //If Y >= mm - a_N Then
        //        //    t1 = Math.Sqrt((4 * Fp_max * (mm - a_N) ^ 2 / 2) / (Phi * fyp))
        //        //ElseIf Y < mm - a_N Then
        //        //    t1 = Math.Sqrt(4 * Fp_max * Y * ((mm - a_N) - Y / 2) / (Phi * fyp))
        //        //End If
                

        //        Tu = Pu >= 0
        //            ? (Fp_max * B) * Y - Pu
        //            : Muy / (N - 2 * a_N) - Pu / 2;
        //        T_rod = Tu / nbN;


        //        var x = f - Sec.h / 2 + Sec.tf / 2;
        //        var t2 = Math.Sqrt(4 * Tu * x / (Phi * B * fyp));

        //        t = Math.Max(t1, t2);
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }

        //    var boltRatio1 = GetBoltRatio(input, Tu, Vux * input.nbN / input.nb, input.nbN);
        //    var boltRatio2 = GetBoltRatio(input, 0, Vux * (1.0 - input.nbN / (double)input.nb), input.nb - input.nbN);
            
        //    boltRatio = MyMath.Max(boltRatio1.Item1, boltRatio2.Item1);
        //    shearKeyRatio = MyMath.Max(boltRatio1.Item2, boltRatio2.Item2);

        //    return 0;
        //}
        
        private DesignResult Design_Moment_Rectangle(BasePlateInput basePlateInput, double Pu, double Vux, double Muy)
        {
            //AISC Steel Design Guide: Base Plate and Anchor Rod Design, Second Edition: Section 4.6
            //Units kg-mm

            var ret = new DesignResult();

            Muy = Math.Abs(Muy);

            var e = Pu == 0.0 
                ? double.Epsilon
                : Math.Abs(Muy / Pu);

            var e1 = basePlateInput.a_N;

            var fp_max = basePlateInput.Phi_c * (0.85 * basePlateInput.fc) * Math.Min(Math.Sqrt(basePlateInput.A2 / basePlateInput.A1), 2.0);
            var q_max = fp_max * basePlateInput.B;
            var e_crit = basePlateInput.N / 2 - Pu / (2 * q_max);

            double t1;
            double Y;
            var fup = 0.0;
            if (e <= e_crit)      //Small Moment
            {
                Y = basePlateInput.N - 2 * e;

                var q = Pu / Y;
                if (q > q_max)
                {
                    throw new Exception();
                }

                var m = (basePlateInput.N - 0.95 * basePlateInput.Sec.h) / 2.0;
                
                fup = Math.Max(Pu / (basePlateInput.B * Y), 0);
                ret.fup = fup;
                ret.BearingRatio = fup / basePlateInput.Fp_max;
                if (fup > basePlateInput.Fp_max)
                {
                    ret.ErrorMessages.Add("Increase base plate dimensions!!");
                    ret.Succeed = false;
                    return ret;
                }

                //Eq. 3.3.14a-1 & 3.3.14b-1
                t1 = Y >= mm
                    ? Math.Sqrt(4 * fup * Math.Pow(mm, 2) / 2 / (basePlateInput.Phi * basePlateInput.fyp))        //LRFD
                    : Math.Sqrt(4 * fup * Y * (mm - Y / 2) / (basePlateInput.Phi * basePlateInput.fyp));          //ASD

                ret.Ml = 0;
                ret.Tu = 0;
                ret.t = t1;
                ret.ts = 0;
                ret.BoltRatio = 0;
                ret.Succeed = true;
                return ret;
            }
            if (e > e_crit)       //Large Moment
            {
                double T_rod = 0;
                var f = basePlateInput.N / 2 - basePlateInput.a_N;

                double Y1;
                double Y2;
                if (Pu > 0)
                {
                    Y1 = (f + basePlateInput.N / 2) + Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Pu * (e + f) / (basePlateInput.Fp_max * basePlateInput.B));
                    Y2 = (f + basePlateInput.N / 2) - Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Pu * (e + f) / (basePlateInput.Fp_max * basePlateInput.B));
                }
                else if (Pu < 0)
                {
                    e = Math.Abs(e);
                    Y1 = (f + basePlateInput.N / 2) + Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Pu * (f - e) / (basePlateInput.Fp_max * basePlateInput.B));
                    Y2 = (f + basePlateInput.N / 2) - Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Pu * (f - e) / (basePlateInput.Fp_max * basePlateInput.B));
                }
                else// if (Pu == 0)
                {
                    Y1 = (f + basePlateInput.N / 2) + Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Muy / (basePlateInput.Fp_max * basePlateInput.B));
                    Y2 = (f + basePlateInput.N / 2) - Math.Sqrt(Math.Pow((f + basePlateInput.N / 2), 2) - 2 * Muy / (basePlateInput.Fp_max * basePlateInput.B));
                }

                if (double.IsNaN(Y1) && double.IsNaN(Y2))
                {
                    ret.ErrorMessages.Add("Increase base plate dimensions!!");
                    ret.Succeed = false;
                    return ret;
                }

                Y = MyMath.Min(Y1, Y2);
                if (Y > 0)
                {
                    fup = Math.Max(Pu / (basePlateInput.B * Y), 0);
                    ret.fup = fup;
                    ret.BearingRatio = fup / basePlateInput.Fp_max;
                    if (fup > basePlateInput.Fp_max)
                    {
                        ret.ErrorMessages.Add("Increase base plate dimensions!!");
                        ret.Succeed = false;
                        return ret;
                    }

                    // For Tension
                    //Eq. 3.3.14a-1 & 3.3.14b-1
                    t1 = Y >= mm
                        ? Math.Sqrt(4 * basePlateInput.Fp_max * Math.Pow(mm, 2) / 2 / (basePlateInput.Phi * basePlateInput.fyp))
                        : Math.Sqrt(4 * basePlateInput.Fp_max * Y * (mm - Y / 2) / (basePlateInput.Phi * basePlateInput.fyp));
                    //If Y >= mm - a_N Then
                    //    t1 = Math.Sqrt((4 * Fp_max * (mm - a_N) ^ 2 / 2) / (Phi * fyp))
                    //ElseIf Y < mm - a_N Then
                    //    t1 = Math.Sqrt(4 * Fp_max * Y * ((mm - a_N) - Y / 2) / (Phi * fyp))
                    //End If
                }
                else
                {
                    t1 = 0;
                }

                var Tu = Pu >= 0
                    ? (basePlateInput.Fp_max * basePlateInput.B) * Y - Pu
                    : Muy / (basePlateInput.N - 2 * basePlateInput.a_N) - Pu / 2;
                T_rod = Tu / basePlateInput.nbN;


                var x = f - basePlateInput.Sec.h / 2 + basePlateInput.Sec.tf / 2;
                var t2 = Math.Sqrt(4 * Tu * x / (basePlateInput.Phi * basePlateInput.B * basePlateInput.fyp));

                var boltRatio1 = GetBoltRatio(basePlateInput, Tu, Vux * basePlateInput.nbN / basePlateInput.nb, basePlateInput.nbN);
                var boltRatio2 = GetBoltRatio(basePlateInput, 0, Vux * (1.0 - basePlateInput.nbN / (double)basePlateInput.nb), basePlateInput.nb - basePlateInput.nbN);

                ret.Ml = 0;
                ret.Tu = Tu;
                ret.t = Math.Max(t1, t2);
                ret.ts = 0;
                ret.BoltRatio = MyMath.Max(boltRatio1.Item1, boltRatio2.Item1);
                ret.ShearKeyRatio = MyMath.Max(boltRatio1.Item2, boltRatio2.Item2);
                ret.Succeed = true;
                return ret;
            }
            else
            {
                ret.Succeed = false;
                return ret;
            }
        }

        private DesignResult Design_Moment_Rectangle_WithStiffener(BasePlateInput basePlateInput, double Pu, double Vux, double Muy)
        {
            var ret = new DesignResult();

            switch (basePlateInput.StiffnerType)
            {
                default:
                    ret.Succeed = false;
                    return ret;
            }
        }

        private DesignResult Design_Moment_Triangle(BasePlateInput basePlateInput, double Pu, double Vux, double Muy)
        {
            var ret = new DesignResult();

            if (basePlateInput.StiffnerType == 0)
            {
                double Mpl = 0;
                var ep_max = basePlateInput.N / 6;

                double t1;
                var e = Pu == 0.0
                    ? double.Epsilon
                    : Math.Abs(Muy / Pu);

                if (e <= ep_max)
                {
                    var fupa = Pu / (basePlateInput.B * basePlateInput.N);
                    var fupb = 6 * Pu * e / (basePlateInput.B * Math.Pow(basePlateInput.N, 2));

                    var fup1 = fupa + fupb;
                    var fupm = fup1 - 2 * fupb * mm / basePlateInput.N;
                    Mpl = (fup1 - 2 * fupb * mm / basePlateInput.N) * (Math.Pow(mm, 2) / 2) + 2 * fupb * (mm / basePlateInput.N) * (Math.Pow(mm, 2) / 3);

                    t1 = Math.Sqrt(4 * Mpl / (basePlateInput.Phi_b * basePlateInput.B * basePlateInput.fyp));

                    //fup = 0;
                    throw new Exception("fup??????????");
                    //ret.BearingRatio = fup / Fp_max;

                    //if (fup >= Fp_max)
                    //{
                    //    return null;
                    //}

                    //ret.Ml = 0;
                    //ret.Tu = 0;
                    //ret.t = t1;
                    //ret.ts = 0;
                    //ret.BoltRatio = 0;
                    //ret.Succeed = true;
                    //return ret;
                }

                var f = basePlateInput.N / 2 - basePlateInput.a_N;
                var N1 = basePlateInput.N - basePlateInput.a_N;
                var f1 = (basePlateInput.PHI_AL * basePlateInput.FP) * basePlateInput.B * N1 / 2;
                var Y = (f1 - Math.Sqrt(Math.Pow(f1, 2) - 4 * ((basePlateInput.PHI_AL * basePlateInput.FP) * basePlateInput.B / 6) * (Pu * f + Muy))) / ((basePlateInput.PHI_AL * basePlateInput.FP) * basePlateInput.B / 3);
                var Tu = (basePlateInput.PHI_AL * basePlateInput.FP) * Y * basePlateInput.B / 2 - Pu;

                var x = (Y - (basePlateInput.N - basePlateInput.Sec.h) / 2) * (basePlateInput.PHI_AL * basePlateInput.FP) / Y;
                Mpl = x * Math.Pow(((basePlateInput.N - basePlateInput.Sec.h) / 2 + basePlateInput.Sec.bf / 2), 2) / 2;
                Mpl = Tu * (x - basePlateInput.a_N) / (2 * (x - basePlateInput.a_N));

                t1 = Math.Sqrt(4 * Mpl / (basePlateInput.Phi * basePlateInput.fyp));

                ret.Ml = 0;
                ret.Tu = Tu;
                ret.t = t1;
                ret.ts = 0;
                //   ret.BoltRatio = GetBoltRatio(Tu, Vux, Anb, nb)
                ret.Succeed = true;
                return ret;
            }

            ret.Succeed = false;
            return ret;
        }

        private (double, double) GetBoltRatio(BasePlateInput basePlateInput, double Nu, double Vu, int n1)
        {
            var BoltRatio = 0.0;
            var ShearKeyRatio = 0.0;

            if (basePlateInput.DesignMethod == DesignMethod.ASCE7_ASD)
            {
                Nu *= 1.5;
                Vu *= 1.5;
            }

            double Nn;
            double Phi_N;
            double Phi_V;

            var Anb = basePlateInput.AnchorBolt.Ase;

            switch (basePlateInput.ShearResistance)
            {
                case ShearResistance.ShearKey:
                    
                    Nn = n1 * Anb * basePlateInput.fub;

                    Phi_N = 0.75;
                    BoltRatio = Nu / (Phi_N * Nn);

                    ShearKeyRatio = GetShearKeyRatio(basePlateInput, Vu);
                    break;
                case ShearResistance.AnchorBolt:

                    Phi_N = 0.75;
                    Phi_V = 0.65;

                    Phi_V *= 0.6;

                    if (basePlateInput.GroutPad)
                    {
                        Phi_V *= 0.8;
                    }

                    Nn = n1 * Anb * basePlateInput.fub;
                    var Vn = n1 * Anb * basePlateInput.fub;

                    document.AddFormula(@$"N_n = n A_{{nb}} F_{{u,b}}  = {Nn / 1000:F1} \: kN");

                    if (Nu / (Phi_N * Nn) <= 0.2 && Vu / (Phi_V * Vn) > 0.2)
                    {
                        BoltRatio = Vu / (Phi_V * Vn);
                    }
                    else if (Vu / (Phi_V * Vn) <= 0.2 && Nu / (Phi_N * Nn) > 0.2)
                    {
                        BoltRatio = Nu / (Phi_N * Nn);
                    }
                    else
                    {
                        BoltRatio = (Nu / (Phi_N * Nn)) + (Vu / (Phi_V * Vn));
                        BoltRatio = BoltRatio / 1.2;

                        BoltRatio = MyMath.Max(BoltRatio, Vu / (Phi_V * Vn), Nu / (Phi_N * Nn));
                    }

                    document.AddFormula(@$"f = min( \frac{{ V_u }}{{ {{\phi}}_v V_n }}, \frac{{ N_u }}{{ {{\phi}}_n N_n }}, \frac{{ V_u }}{{ 1.2 {{\phi}}_v V_n }} + \frac{{ N_u }}{{ 1.2 {{\phi}}_n N_n }}  ) = {BoltRatio:F3} \: MPa");

					break;
                    //Ratio = (Nu1 / Nn) ^ (5 / 3) + (Vu1 / Vn) ^ (5 / 3)
            }

            return (BoltRatio, ShearKeyRatio);
        }
        
        private double GetShearKeyRatio(BasePlateInput basePlateInput, double Vu)
        {
            const double TOLERANCE = 0.00001;

            if (basePlateInput.DesignMethod == DesignMethod.ASCE7_ASD)
            {
                Vu *= 1.5;
            }

            if (Math.Abs(Vu) < TOLERANCE)
            {
                return 0;
            }

            var ClearShearKeyHeight = basePlateInput.ShearKeyHeight - basePlateInput.GroutThickness;

            var A_req = Vu / (0.85 * 0.65 * basePlateInput.fc);
            var Mu = Vu * (basePlateInput.GroutThickness + ClearShearKeyHeight / 2);

            double A_exit;
            double Mn;
            if (basePlateInput.ShearKeySection is SectionPipe Pipe)
            {
                A_exit = Pipe.od * ClearShearKeyHeight;
                Mn = 0.9 * Math.Min(Pipe.Zx, Pipe.Zy) * basePlateInput.fyc;

                return Math.Max(A_req / A_exit, Mu / Mn);

            }

            if (basePlateInput.ShearKeySection is SectionI I)
            {
                switch (basePlateInput.ShearKeyOrientation)
                {
                    case 0:         //Majopr
                        A_exit = I.bf * ClearShearKeyHeight;
                        Mn = 0.9 * I.Zx * basePlateInput.fyc;
                        return Math.Max(A_req / A_exit, Mu / Mn);
                    case 1:         //Monor
                        A_exit = I.h * ClearShearKeyHeight;
                        Mn = 0.9 * I.Zy * basePlateInput.fyc;
                        return Math.Max(A_req / A_exit, Mu / Mn);
                }
                return 0;

            }

            if (basePlateInput.ShearKeySection is SectionTube Tube)
            {
                A_exit = Tube.h * ClearShearKeyHeight;
                A_exit = Tube.bf * ClearShearKeyHeight;

                Mn = 0.9 * Tube.Zx * basePlateInput.fyc;
                Mn = 0.9 * Tube.Zy * basePlateInput.fyc;

                return Math.Max(Math.Max(A_req / A_exit, Mu / Mn), Math.Max(A_req / A_exit, Mu / Mn));
            }

            return -1;
        }

        public void CheckAnchorBolts(BasePlateInput input)
        {

            //Rebars
            var Lx = input.Np - 2 * input.Cover;
            var Ly = input.Bp - 2 * input.Cover;

            var dx = Lx / (input.nrN - 1);
            var dy = Ly / (input.nrB - 1);

			var barLocation = new List<(double, double)>();

			for (var j = 0; j < input.nrB; j++)
            {
	            if (j == 0 || j == input.nrB - 1)
	            {
		            for (var i = 0; i < input.nrN; i++)
		            {
			            barLocation.Add((-Lx / 2 + i * dx, -Ly/2 + j * dy));
		            }
	            }
	            else
	            {
		            barLocation.Add((-Lx / 2, -Ly / 2 + j * dy));
		            barLocation.Add((-Lx / 2 + (input.nrN - 1) * dx, -Ly / 2 + j * dy));
				}
            }

            //Anchor bolts
			Lx = input.N - 2 * input.a_N;
			Ly = input.B - 2 * input.a_B;

			dx = Lx / (input.nbN - 1);
			dy = Ly / (input.nbB - 1);

			var anchorLocation = new List<(double, double)>();
			for (var j = 0; j < input.nbB; j++)
			{
				if (j == 0 || j == input.nbB - 1)
				{
					for (var i = 0; i < input.nbN; i++)
					{
						barLocation.Add((-Lx / 2 + i * dx, -Ly / 2 + j * dy));
					}
				}
				else
				{
					barLocation.Add((-Lx / 2, -Ly / 2 + j * dy));
					barLocation.Add((-Lx / 2 + (input.nbN - 1) * dx, -Ly / 2 + j * dy));
				}
			}


		}
    }
}
