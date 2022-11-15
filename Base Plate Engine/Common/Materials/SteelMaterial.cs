using System;
using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Common.Materials
{
    public sealed class SteelMaterial : Material
    {
        public SteelMaterial(string name, string category, double Fu, double Fy, double Es, bool userDefined)
        {
            this.Name = name;
            this.Category = category;
            this.Fu = Fu;
            this.Fy = Fy;
            this.Es = Es;
            this.UserDefined = userDefined;
        }

        public string Name { get; }

        public string Category { get; }

        public bool UserDefined { get; }

        public double Fu { get; }

        public double Fy { get; }

        public double Es { get; }
    }
}
