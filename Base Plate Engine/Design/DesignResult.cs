using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Design
{
    public class DesignResult
    {
        private static readonly int[] PlateThicknesses = { 8, 10, 12, 15, 20, 25, 30, 35, 40, 50, 60 };

        public double t { get; set; }
        public double Tu { get; set; }
        public double fup { get; set; }
        public double Ml { get; set; }
        public double ts { get; set; }
        public double BoltRatio { get; set; }
        public double ShearKeyRatio { get; set; }
        public double WeldRatio_BP { get; set; }
        public double WeldRatio_SK { get; set; }
        public double BearingRatio { get; set; }
        public double PedestalRatio { get; set; }
        public double PedestalShearRatio { get; set; }

        public List<string> DesignMessage = new List<string>();
        public List<string> ErrorMessages = new List<string>();
        public List<string> WarningMessages = new List<string>();

        public bool Succeed = false;

        public double t_req
        {
            get
            {
                var tt = PlateThicknesses.First(p => t <= p);
                return tt;

                //foreach (var t1 in PlateThicknesses)
                //{
                //    if (t < t1)
                //    {
                //        return t1;
                //    }
                //}

                //return PlateThicknesses[PlateThicknesses.Length - 1];
            }
        }

        public static DesignResult GetCritical(DesignResult[] results)
        {
            return new DesignResult
            {
                t = results.Max(p => p.t),
                BoltRatio = results.Max(p => p.BoltRatio),

                fup = results.Max(p => p.fup),
                BearingRatio = results.Max(p => p.BearingRatio),
                ShearKeyRatio = results.Max(p => p.ShearKeyRatio),
                WeldRatio_BP = results.Max(p => p.WeldRatio_BP),
                WeldRatio_SK = results.Max(p => p.WeldRatio_SK),

                PedestalRatio = results.Max(p => p.PedestalRatio),
                PedestalShearRatio = results.Max(p => p.PedestalShearRatio),

                Tu = results.Max(p => p.Tu),
                ts = results.Max(p => p.ts),
                Succeed = true
            };
        }
    }
}
