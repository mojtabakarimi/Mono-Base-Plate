using Base_Plate_Engine.Common.Materials;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public static class SteelMaterialFactory
    {
        public static ImmutableArray<SteelMaterial> Items { get; }

        static SteelMaterialFactory()
        {
            var list = new List<SteelMaterial>()
            {
                new SteelMaterial("ST37", "", 370, 240, 200_000, true),

                new SteelMaterial("A992", "US ASTM", 448, 345, 200_000, true),
                new SteelMaterial("A572 Gr.50", "US ASTM", 448, 345, 200_000, true),
                new SteelMaterial("A36", "US ASTM", 400, 248, 200_000, true),
                new SteelMaterial("A913 Gr.50", "US ASTM", 414, 345, 200_000, true),
                new SteelMaterial("A913 Gr.60", "US ASTM", 517, 414, 200_000, true),
                new SteelMaterial("A913 Gr.65", "US ASTM", 552, 448, 200_000, true),

                new SteelMaterial("A53M-B", "US ASTM", 415, 240, 200_000, true),

                new SteelMaterial("S235 t≤t16mm", "Europe/UK BS EN10025-2", 360, 235, 200_000, true),
                new SteelMaterial("S235 t>t16mm", "Europe/UK BS EN10025-2", 360, 225, 200_000, true),
                new SteelMaterial("S275 t≤t16mm", "Europe/UK BS EN10025-2", 410, 275, 200_000, true),
                new SteelMaterial("S275 t>t16mm", "Europe/UK BS EN10025-2", 410, 265, 200_000, true),
                new SteelMaterial("S355 t≤t16mm", "Europe/UK BS EN10025-2", 470, 355, 200_000, true),
                new SteelMaterial("S355 t>t16mm", "Europe/UK BS EN10025-2", 470, 345, 200_000, true),

                new SteelMaterial("Q235 t≤t16mm", "China", 375, 235, 200_000, true),
                new SteelMaterial("Q235 t>t16mm", "China", 375, 225, 200_000, true),
                new SteelMaterial("Q345 t≤t16mm", "China", 470, 345, 200_000, true),
                new SteelMaterial("Q345 t>t16mm", "China", 470, 325, 200_000, true),

                new SteelMaterial("350W", "Canada", 448, 345, 200_000, true),
                new SteelMaterial("300W", "Canada", 448, 303, 200_000, true),
                new SteelMaterial("260W", "Canada", 414, 262, 200_000, true),
            };

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
