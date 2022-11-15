using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Common.Materials
{
    public sealed class WeldMaterial : Material
    {
        public WeldMaterial(string name, string category, double fu)
        {
            Name = name;
            Category = category;
            Fu = fu;
        }

        public string Name { get; }

        public string Category { get; }

        public bool UserDefined { get; }

        public double Fu { get; }
    }
}
