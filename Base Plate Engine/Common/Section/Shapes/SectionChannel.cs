using System;

namespace Base_Plate_Engine.Common.Section.Shapes
{
    public class SectionChannel : Base.Section
    {
        public SectionChannel(
            string name,
            string category,
            string library,
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
            : base(name, category, library, A, J, Ix, Iy, Vy, Vx, Sx, Sy, Zx, Zy, rx, ry)
        {


        }

        public override double Perimeter { get; }
        public override bool IsCompact { get; }

        public static SectionChannel Create()
        {
            throw new NotImplementedException();
        }
    }
}
