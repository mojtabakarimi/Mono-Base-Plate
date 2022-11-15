namespace Base_Plate_Engine.Common.Section.Interfaces
{
    public interface ISection
    {
        string Name { get; }
        double A { get; }
        double J { get; }
        double Ix { get; }
        double Iy { get; }
        double Vy { get; }
        double Vx { get; }
        double Sx { get; }
        double Sy { get; }
        double Zx { get; }
        double Zy { get; }
        double rx { get; }
        double ry { get; }
    }
}
