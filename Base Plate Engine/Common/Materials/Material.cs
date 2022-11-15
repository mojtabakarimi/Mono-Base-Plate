namespace Base_Plate_Engine.Common.Materials
{
    public interface Material
    {
        string Name { get; }

        string Category { get; }

        bool UserDefined { get; }
    }
}
