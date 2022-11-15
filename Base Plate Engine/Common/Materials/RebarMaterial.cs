using System;
using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Common.Materials
{
    public sealed class RebarMaterial : Material
    {
        public RebarMaterial(string name, string category, double Fu, double Fy)
        {
            Name = name;
            Category = category;
            this.Fu = Fu;
            this.Fy = Fy;
        }

        public string Name { get; }

        public string Category { get; }
        public bool UserDefined { get; }

        public double Fu { get; }

        public double Fy { get; }
    }
}
