using Base_Plate_Engine.Common.Materials;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public static class BoltMaterialFactory
    {
        public static ImmutableArray<BoltMaterial> Items;

        static BoltMaterialFactory()
        {
            var list = new List<BoltMaterial>
            {
                new BoltMaterial("A325-N", "ASTM", 800, 620, 372, false, false),
                new BoltMaterial("A325-X", "ASTM", 800, 620, 469, true, false),
                new BoltMaterial("A490-N", "ASTM", 1000, 780, 469,false, false),
                new BoltMaterial("A490-X", "ASTM", 1000, 780, 579, true, false),
                new BoltMaterial("8.8-N", "DIN", 800, false, false),
                new BoltMaterial("8.8-X", "DIN", 800, true, false),
                new BoltMaterial("10.9-N", "DIN", 1000, false, false),
                new BoltMaterial("10.9-X", "DIN", 1000, true, false)
            };

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
