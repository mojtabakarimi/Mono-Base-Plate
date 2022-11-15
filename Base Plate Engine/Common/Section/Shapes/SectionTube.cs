using System;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public class SectionTube : Base.Section
    {
        public float h { get; }

        public float bf { get; }

        public float tf { get; }

        public float tw { get; }

        private float d { get; }

        public SectionTube(string name,
            float h,
            float bf,
            float tf,
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
            this.h = h;
            this.bf = bf;
            this.tf = tf;
            this.tw = tw;

            this.d = h - 2 * tf;
        }


        public override double Perimeter => 0.0;

        public override bool IsCompact => true;

        public static SectionTube Create(string name, float h, float bf, float tf, float tw)
        {
            var d = h - 2 * tf;

            var A = (2 * d * tw + 2 * bf * tf);
            var J = double.NaN;
             
            var Vy = double.NaN;
            var Vx = double.NaN;
             
            var Ix = 2 * tw * Math.Pow(d, 3) / 12 + 2 * (bf * Math.Pow(tf, 3) / 12 + tf * bf * Math.Pow((d / 2 + tf / 2), 2));
            var Iy = 2 * tf * Math.Pow(bf, 3) / 12 + 2 * (d * Math.Pow(tw, 3) / 12 + d * tw * Math.Pow((bf / 2 - tf / 2), 2));
             
            var Zx = 2 * (2 * tw * d / 2 * d / 4 + bf * tf * (d / 2 + tf / 2));
            var Zy = 2 * (2 * tf * bf / 2 * bf / 4 + tw * d * (bf / 2 - tw / 2));
             
            var Sx = Ix / (h / 2);
            var Sy = Iy / (bf / 2);
             
            var rx = Math.Sqrt(Ix / A);
            var ry = Math.Sqrt(Iy / A);

            return new SectionTube(name, h, bf, tf,tw, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry);
        }
    }
}
