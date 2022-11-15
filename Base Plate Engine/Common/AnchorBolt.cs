using System;
using System.Collections.Generic;
using Base_Plate_Engine.Common.Mathematics;
using Base_Plate_Engine.Properties;

namespace Base_Plate_Engine.Common
{
    public class AnchorBolt
    {
        public AnchorBolt(string name, double da, double As0, double Ase, double H, double SL, double D, double W, double T, double N1, double N2, double Phi_e, double e, double S, double WasherPlate)
        {
            Name = name;
            this.da = da;
            this.As0 = As0;
            this.Ase = Ase;
            this.H = H;
            this.SL = SL;
            this.D = D;
            this.W = W;
            this.T = T;
            this.N1 = N1;
            this.N2 = N2;
            this.Phi_e = Phi_e;
            this.e = e;
            this.S = S;
            this.WasherPlate = WasherPlate;
        }

        private const string AnchorType = "CZ";

        public string Name { get; }

        public double da { get; }
        public double As0 { get; }
        public double Ase { get; }
        public double H { get; }
        public double SL { get; }
        public double D { get; }
        public double W { get; }
        public double T { get; }
        public double N1 { get; }
        public double N2 { get; }          //washer plate width
        public double Phi_e { get; }
        public double e { get; }
        public double S { get; }
        public double WasherPlate { get; }

        //public string Projection => AnchorType + ((GroutThickness + Main.BP.DesignResult.t_req + N2 + WasherPlate) * 10).RoundUpTo(5).ToString("0") + "-" + (SL * 10).ToString("0") + "X";

        public string Projection(double GroutThickness, double t_req) => AnchorType + ((GroutThickness + t_req + N2 + WasherPlate) * 10).RoundUpTo(5).ToString("0") + "-" + (SL * 10).ToString("0") + "X";

    }
}
