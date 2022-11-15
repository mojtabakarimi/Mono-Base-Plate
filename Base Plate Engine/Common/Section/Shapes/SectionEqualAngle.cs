using System;
using System.Collections;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public sealed class SectionEqualAngle : Base.Section, IComparer
    {
        public SectionEqualAngle(
            string Name, 
            float b,
            float t,
            float r1,
            float r2, 
            float e,
            float w,
            float v1,
            double A,
            double J,
            double Ix, 
            double Iy, 
            double Vy,
            double Vx,
            double Sx,
            double Sy, 
            double Zx,
            double Zy,
            double rx,
            double ry)
            : base(Name, "", "", A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry)
        {
            this.b = b;
            this.t = t;
            this.r1 = r1;
            this.r2 = r2;
        }

        /// <summary>
        /// Width, mm
        /// </summary>
        public float b { get; }

        /// <summary>
        /// Thickness
        /// </summary>
        public float t { get; }

        public float e { get; }

        public float r1 { get; }

        public float r2 { get; }

        public float rmin { get; }

        public float rmax { get; }

        public override double Perimeter => 0.0;

        public override bool IsCompact => true;

        public static SectionEqualAngle Create()
        {
            throw new NotImplementedException();
        }
    }
}
