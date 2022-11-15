using System;
using System.Collections;

namespace Base_Plate_Engine.Design.Sections
{
    public class SectionBox : Section
    {
        public  double h { get; }
        public  double bf { get; }
        public  double tf { get; }
        public  double tw { get; }
        private double d { get; }

        public SectionBox(string Name, double h, double bf, double tf, double tw)
        {
            this.Name = Name;

            this.h = h;
            this.bf = bf;
            this.tf = tf;
            this.tw = tw;

            d = h - 2 * tf;

            A = (2 * d * tw + 2 * bf * tf);
            J = 0;

            V22 = 0;
            V33 = 0;

            I33 = 2 * tw * Math.Pow(d, 3) / 12 + 2 * (bf * Math.Pow(tf, 3) / 12 + tf * bf * Math.Pow((d / 2 + tf / 2), 2));
            I22 = 2 * tf * Math.Pow(bf, 3) / 12 + 2 * (d * Math.Pow(tw, 3) / 12 + d * tw * Math.Pow((bf / 2 - tf / 2), 2));

            Z33 = 2 * (2 * tw * d / 2 * d / 4 + bf * tf * (d / 2 + tf / 2));
            Z22 = 2 * (2 * tf * bf / 2 * bf / 4 + tw * d * (bf / 2 - tw / 2));

            S33 = I33 / (h / 2);
            S22 = I22 / (bf / 2);

            r33 = Math.Sqrt(I33 / A);
            r22 = Math.Sqrt(I22 / A);
        }
    }
}
