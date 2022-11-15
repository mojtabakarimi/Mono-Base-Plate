using Base_Plate_Engine.Common.Materials;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public static class RebarMaterialFactory
    {
        public static ImmutableArray<RebarMaterial> Items { get; }

        static RebarMaterialFactory()
        {
            var list = new List<RebarMaterial>()
            {
                new RebarMaterial("S340 (A2)", "", 500, 340),
                new RebarMaterial("S400 (A3)", "", 600, 400),
                new RebarMaterial("S500 (A4)", "", 650, 500),
            };

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
