using Base_Plate_Engine.Common.Materials;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public  static class WeldMaterialFactory
    {
        public static ImmutableArray<WeldMaterial> Items { get; }
        static WeldMaterialFactory()
        {
            var list = new List<WeldMaterial>
            {
                //new WeldMaterial("E43XX", 414),
                //new WeldMaterial("E49XX", 483),
                //new WeldMaterial("E55XX", 552),
                new WeldMaterial("E60XX", "", 414),     //60 ksi
                new WeldMaterial("E70XX", "", 483)      //70 ksi
            };

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
