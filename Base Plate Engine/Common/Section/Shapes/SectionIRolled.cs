using System;
using System.Collections;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public sealed class SectionIRolled : SectionI
    {
        /// <summary>
        /// 
        /// </summary>
        public float r { get; }

        /// <summary>
        /// 
        /// </summary>
        public float kc => tf + r;

        public float h_2c => d - 2 * kc;

        public SectionIRolled(string name, string library, string category, float d, float bf, float tf, float tw, float r, double A, double J, double Ix, double Iy, double Vy, double Vx, double Sx, double Sy, double Zx, double Zy, double rx, double ry) 
            : base(name, library, category, d, bf, tf, tw, r, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry)
        {

        }

        public override double Perimeter => 2 * bf + 2 * (bf - tw) + 2 * (d - 2 * tf - 2 * r);
        
        public override bool IsCompact => true;

        public override string ToString()
        {
            return $"{Category}: {Name}";
        }
    }
}
