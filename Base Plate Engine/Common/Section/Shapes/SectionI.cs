using System;
using System.Collections;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public class SectionI : Base.Section, IComparer
    {
        /// <summary>
        /// Total height, mm
        /// </summary>
        public float d { get; }

        /// <summary>
        /// Web height, mm
        /// </summary>
        public float h => d - 2 * tf;
        public float d1 { get; }

        /// <summary>
        /// Flange width, mm
        /// </summary>
        public float bf { get; }

        /// <summary>
        /// Flange thickness, mm
        /// </summary>
        public float tf { get; }

        /// <summary>
        /// Web thickness
        /// </summary>
        public float tw { get; }

        /// <summary>
        /// 
        /// </summary>
        public float r { get; }

        /// <summary>
        /// 
        /// </summary>
        public float kc => tf + r;

        public float h_2c => d - 2 * kc;

        public SectionI(string name, string library, string category, float d, float bf, float tf, float tw, float r, double A, double J, double Ix, double Iy, double Vy, double Vx, double Sx, double Sy, double Zx, double Zy, double rx, double ry) 
            : base(name, category, library, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry)
        {
            this.d = d;
            this.bf = bf;
            this.tf = tf;
            this.tw = tw;
            this.r = r;

            d1 = d - 2 * tf;
        }

        public override double Perimeter => 2 * bf + 2 * (bf - tw) + 2 * (d - 2 * tf - 2 * r);
        
        public override bool IsCompact => true;

        public static SectionI Create(string name, float d, float bf, float tf, float tw, float r)
        {
            var d1 = d - 2 * tf;
             
            var A = 2 * tf * bf + (d - 2 * tf) * tw;
            var J = 1 / 3.0 * (2 * bf * Math.Pow(tf, 3) + (d - 2 * tf) * Math.Pow(tw, 3));
             
            var Ix = (bf * Math.Pow(d, 3) - (bf - tw) * Math.Pow(d - 2 * tf, 3)) / 12.0;
            var Iy = 2 * tf * Math.Pow(bf, 3) / 12.0 + (d - 2 * tf) * Math.Pow(tw, 3) / 12.0;
             
            var Vy = 2 * tf * bf / 1.2;
            var Vx = d * tw;
             
            var Sx = Ix / (d / 2.0);
            var Sy = Iy / (bf / 2.0);
            
            var Zx = 2 * (Math.Pow(d - 2 * tf, 2) / 8 * tw + bf * tf * (d - tf) / 2.0);
            var Zy = Math.Pow(bf, 2) * tf / 2.0 + (d - 2 * tf) * Math.Pow(tw, 2) / 4.0;
             
            var rx = Math.Sqrt(Ix / A);
            var ry = Math.Sqrt(Iy / A);

            return new SectionI(name, "", "", d, bf, tf, tw, r, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry);
        }
    }
}
