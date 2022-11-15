using System;
using System.Collections;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public sealed class SectionPipe : Base.Section, IComparer
    {
        public float od { get; }
        public float tw { get; }

        public SectionPipe(
            string name,
            float od,
            float tw,
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
            : base(name, "", "", A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry)
        {
            this.od = od;
            this.tw = tw;
        }

        public override double Perimeter => 0.0;

        public override bool IsCompact => true;

        public static SectionPipe Create(string name, string library, string category, float od, float tw)
        {
            var id = od - 2 * tw;

            var A = Math.PI / 4 * (Math.Pow(od, 2) - Math.Pow(id, 2));
            
            var Ix = Math.PI / 64 * (Math.Pow(od, 4) - Math.Pow(id, 4));
            var Iy = Ix;

            var J = 2 * Ix;

            var Vy = 0.0;
            var Vx = Vy;

            var Sx = Ix / (od / 2.0);
            var Sy = Sx;

            var Zx = Ix * (2 / od);
            var Zy = Zx;

            var rx = Math.Sqrt(Ix / A);
            var ry = rx;

            return new SectionPipe(name, od, tw, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry);
        }
    }
}
