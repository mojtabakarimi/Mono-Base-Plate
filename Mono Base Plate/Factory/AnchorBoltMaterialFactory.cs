using Base_Plate_Engine.Common.Materials;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public class AnchorBoltMaterialFactory
    {
        public static ImmutableArray<AnchorBoltMaterial> Items { get; }

        static AnchorBoltMaterialFactory()
        {
            var list = new List<AnchorBoltMaterial>
            {
                new AnchorBoltMaterial("A307", "ASTM", 400, 248),         // 58 ksi,  36 ksi
                new AnchorBoltMaterial("A36", "ASTM", 400, 248),          // 58 ksi,  36 ksi
                new AnchorBoltMaterial("A354-BC", "ASTM", 862, 751),      //125 ksi, 109 ksi
                new AnchorBoltMaterial("A449", "ASTM", 724, 558),         //105 ksi,  81 ksi
                new AnchorBoltMaterial("A193-B7", "ASTM", 862, 724),      //125 ksi, 105 ksi
                new AnchorBoltMaterial("F1554 Gr.36", "ASTM", 400, 248),     // 58 ksi,  36 ksi
                new AnchorBoltMaterial("F1554 Gr.55", "ASTM", 517, 380),     // 75 ksi,  55 ksi
                new AnchorBoltMaterial("F1554 Gr.105", "ASTM", 862, 724),    //125 ksi, 105 ksi
            };

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
