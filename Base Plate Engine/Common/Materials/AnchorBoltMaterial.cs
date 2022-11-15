using System.Collections.Generic;

namespace Base_Plate_Engine.Common.Materials
{
    public sealed class AnchorBoltMaterial: Material
    {
       

        public AnchorBoltMaterial(string name, string category, double fub, double fyb)
        {
            Name = name;
            Category = category;
            Fub = fub;
            Fyb = fyb;
        }

        public string Name { get; }

        public string Category { get; }

        public bool UserDefined { get; }

        public double Fub { get; }
        
        public double Fyb { get; }
    }
}
