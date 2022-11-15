using Mono_Base_Plate.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base_Plate_Engine.Common;

namespace Mono_Base_Plate.Factory
{
    public static class AnchorBoltFactory
    {
        public static ImmutableArray<AnchorBolt> Items { get; }

        static AnchorBoltFactory()
        {
            var lines = Resources.AnchorBolts.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var list = new List<AnchorBolt>();
            for (var i = 1; i < lines.Length; i++)
            {

                var parts = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                var name = $"M{parts[0]}";

                var da = Convert.ToDouble(parts[0]);
                var As0 = Math.PI * Math.Pow(da, 2) / 4;            //Nominal Area
                var Ase = Convert.ToDouble(parts[1]);         // Net Area

                var H = Convert.ToDouble(parts[2]);
                var SL = Convert.ToDouble(parts[3]);
                var D = Convert.ToDouble(parts[4]);
                var W = Convert.ToDouble(parts[5]);
                var T = Convert.ToDouble(parts[6]);

                var e = Convert.ToDouble(parts[7]);
                var S = Convert.ToDouble(parts[8]);

                var Phi_e = Convert.ToDouble(parts[9]);

                var N1 = Convert.ToDouble(parts[10]);
                var N2 = Convert.ToDouble(parts[11]);

                var WasherPlate = Convert.ToDouble(parts[12]);

                list.Add(new AnchorBolt(name, da, As0, Ase, H, SL, D, W, T, N1, N2, Phi_e, e, S, WasherPlate));
            }

            Items = ImmutableArray.Create(list.ToArray());
        }

    }
}
