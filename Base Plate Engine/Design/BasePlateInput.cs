using System;
using System.Collections.Generic;
using Base_Plate_Engine.Common;
using Base_Plate_Engine.Common.Mathematics;
using Base_Plate_Engine.Common.Section.Interfaces;
using Base_Plate_Engine.Common.Section.Shapes;
using ConcreteDesign.Class;

namespace Base_Plate_Engine.Design
{
    public class BasePlateInput
    {
        public BasePlateInput(
            DesignMethod designMethod,
            BasePlateDesign basePlateDesign,
            AnchorBoltAndPedestalDesignMethod anchorBoltAndPedestalDesign,
            PressureDistribution analysisType,
            int stiffnerType,
            ShearResistance shearResistance,
            WeldType weldType,
            ISection shearKeySection,
            SectionI sec,
            AnchorBolt anchorBolt,
            double N,
            double B,
            double Hp,
            double Np,
            double Bp,
            double N_BPecc,
            double B_BPecc,
            double N_Cecc,
            double B_Cecc,
            double a_N,
            double a_B,
            double hs,
            double clearCover,
            double dr,
            double drs,
            double rsS,
            int nbN,
            int nbB,
            int nrN,
            int nrB, 
            int nrS,
            double fuw, 
            double weldSzieBasePlate,
            double weldSizeShearKey,
            double bettaWeld,
            bool groutPad,
            bool threadeExcluded,
            int shearKeyOrientation,
            double shearKeyHeight,
            double groutThickness,
            double fc,
            double fyp,
            double fyc,
            double es,
            double fub,
            double fyb,
            double fyr,
            double fyrs)
        {
            this.BasePlateDesign = basePlateDesign;
            this.AnchorBoltAndPedestalDesign = anchorBoltAndPedestalDesign;
            this.AnalysisType = analysisType;
            this.StiffnerType = stiffnerType;
            this.ShearResistance = shearResistance;
            this.WeldType = weldType;
            this.ShearKeySection = shearKeySection;
            this.DesignMethod = designMethod;
            this.Sec = sec;
            this.AnchorBolt = anchorBolt;
            this.N = N;
            this.B = B;
            this.Hp = Hp;
            this.Np = Np;
            this.Bp = Bp;
            this.N_BPecc = N_BPecc;
            this.B_BPecc = B_BPecc;
            this.N_Cecc = N_Cecc;
            this.B_Cecc = B_Cecc;
            this.a_N = a_N;
            this.a_B = a_B;
            this.hs = hs;
            this.ClearCover = clearCover;
            this.dr = dr;
            this.drs = drs;
            this.rsS = rsS;
            this.nbN = nbN;
            this.nbB = nbB;
            this.nrN = nrN;
            this.nrB = nrB;
            this.nrS = nrS;
            this.Fuw = fuw;
            this.WeldSzie_BasePlate = weldSzieBasePlate;
            this.WeldSize_ShearKey = weldSizeShearKey;
            this.Betta_Weld = bettaWeld;
            this.GroutPad = groutPad;
            this.ThreadeExcluded = threadeExcluded;
            this.ShearKeyOrientation = shearKeyOrientation;
            this.ShearKeyHeight = shearKeyHeight;
            this.GroutThickness = groutThickness;
            this.fc = fc;
            this.fyp = fyp;
            this.fyc = fyc;
            this.Es = es;
            this.fub = fub;
            this.fyb = fyb;
            this.fyr = fyr;
            this.fyrs = fyrs;

            switch (designMethod)
            {
                case DesignMethod.ASCE7_LRFD:
                    Phi = 0.9;
                    Phi_b = 0.75;
                    PHI_AL = 0.6;
                    PHI_Weld = 0.75;
                    Phi_c = 0.65;
                    break;
                case DesignMethod.ASCE7_ASD:
                    Phi = 0.6;
                    Phi_b = 0.5;
                    PHI_AL = 0.4;
                    PHI_Weld = 0.5;
                    Phi_c = 0.4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.nb = 2 * (this.nbB + this.nbN - 2);                   // Number of total Bolts
            this.nr = 2 * (this.nrB + this.nrN - 2);                   // Number of total rebars

            A1 = this.N * this.B;
            A2 = MyMath.Min((this.Np - 2 * this.N_BPecc) * (this.Bp - 2 * this.B_BPecc), 4 * A1);
            FP = 0.85 * fc * Math.Sqrt(A2 / A1);
            Pp = 0.85 * fc * A1 * Math.Sqrt(A2 / A1);
            Fp_max = Phi_c * FP;
            Pp_max = Phi_c * Pp;

            Cover = ClearCover + dr / 2 + drs;

            this.Awe = 2 * this.Sec.bf + 2 * (this.Sec.bf - this.Sec.tw) + 2 * (this.Sec.h + 2 * this.Sec.tf);

            this.Fnw_BP = this.Betta_Weld * (this.PHI_Weld * (0.6 * this.Fuw) * Math.Sqrt(2) / 2) * this.WeldSzie_BasePlate;
            this.Fnw_SK = this.Betta_Weld * (this.PHI_Weld * (0.6 * this.Fuw) * Math.Sqrt(2) / 2) * this.WeldSize_ShearKey;
        }

        #region Properties
        public DesignMethod DesignMethod { get; }

        public BasePlateDesign BasePlateDesign { get; }

        public AnchorBoltAndPedestalDesignMethod AnchorBoltAndPedestalDesign { get; }

        public PressureDistribution AnalysisType { get; }

        //public List<Loads> LoadsList { get; }
        public SectionI Sec { get; }

        public AnchorBolt AnchorBolt { get; }

        /// <summary>
        /// Dimension of the base plate in X direction, cm
        /// </summary>
        public double N { get; }

        /// <summary>
        /// Dimension of the base plate in Y direction, cm
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Pedestal height, cm
        /// </summary>
        public double Hp { get; }

        /// <summary>
        /// Pedestal dimension in X direction, cm
        /// </summary>
        public double Np { get; }

        /// <summary>
        /// Pedestal dimension in Y direction, cm
        /// </summary>
        public double Bp { get; }

        public double N_BPecc { get; }

        public double B_BPecc { get; }

        public double N_Cecc { get; }

        public double B_Cecc { get; }

        public double a_N { get; }

        public double a_B { get; }

        public int StiffnerType { get; }

        public double hs { get; }

        /// <summary>
        /// Concrete cover to rebar center
        /// </summary>
        public double ClearCover { get; }


        public double dr { get; }

        /// <summary>
        /// rebar diameter (cm)
        /// </summary>
        public double drs { get; }

        /// <summary>
        /// Transverse Rebar Spacing!!
        /// </summary>
        public double rsS { get; }

        /// <summary>
        /// Number of bolts in X direction
        /// </summary>
        public int nbN { get; }

        /// <summary>
        /// Number of bolt in Y direction
        /// </summary>
        public int nbB { get; }

        /// <summary>
        /// Total number of bolts
        /// </summary>
        public int nb { get; }

        public int nrN { get; }

        public int nrB { get; }

        public int nr { get; }

        public int nrS { get; }

        public double Fnw_BP { get; }

        public double Fnw_SK { get; }

        public double Fuw { get; }

        public double WeldSzie_BasePlate { get; }

        /// <summary>
        /// Weld Size cm  'BP:Base Plate     SK:Shear Key
        /// </summary>
        public double WeldSize_ShearKey { get; }

        public double Awe { get; }

        public double Betta_Weld { get; }

        public ShearResistance ShearResistance { get; }

        public WeldType WeldType { get; }

        public ISection ShearKeySection { get; }

        public bool GroutPad { get; } = true;

        public bool ThreadeExcluded { get; }

        public int ShearKeyOrientation { get; }

        public double ShearKeyHeight { get; }

        public double GroutThickness { get; }

        public double FrictionCoefficient { get; } = 0.3;
        
        /// <summary>
        /// Minimum concrete strength, kg/cm2
        /// </summary>
        public double fc { get; }

        /// <summary>
        /// MPa
        /// </summary>
        public double fyp { get; }

        /// <summary>
        /// MPa
        /// </summary>
        public double fyc { get; }

        /// <summary>
        /// Steel modulus of elasticity, kg/cm2
        /// </summary>
        public double Es { get; }

        /// <summary>
        /// Ultimate strength of anchor bolt
        /// </summary>
        public double fub { get; }
        
        /// <summary>
        /// Yield stress of anchor bolt
        /// </summary>
        public double fyb { get; }
        
        /// <summary>
        /// Yield stress of main rebar
        /// </summary>
        public double fyr { get; }
        
        /// <summary>
        /// Yield stress of transverse rebar
        /// </summary>
        public double fyrs { get; }

        /// <summary>
        /// Cover , cm
        /// </summary>
        public double Cover { get; }
        
        public double Phi { get; }
        
        public double Phi_b { get; }
        
        public double PHI_AL { get; }
        
        public double PHI_Weld { get; }
        
        public double Phi_c { get; }
        
        public double A1 { get; }
        
        public double A2 { get; }
        
        public double FP { get; }
        
        public double Pp { get; }
        
        public double Fp_max { get; }

        public double Pp_max { get; }


        public string CompanyName { get; set; }

        public string ProjectName { get; set; }

        public string EngineerName { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        #endregion
    }
}
