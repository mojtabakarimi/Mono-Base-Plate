using Base_Plate_Engine.Common.Section.Shapes;
using Mono_Base_Plate.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public static class SectionIFactory
    {
        public static ImmutableArray<SectionI> Items { get; }

        static SectionIFactory()
        {
            var lines = Resources.Section_I.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<SectionI>();
            for (var i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                var name = parts[0];
                var h = Convert.ToSingle(parts[1]);
                var bf = Convert.ToSingle(parts[2]);
                var tf = Convert.ToSingle(parts[3]);
                var tw = Convert.ToSingle(parts[4]);
                var kc = Convert.ToSingle(parts[5]);
                var A = Convert.ToSingle(parts[6]);
                var J = Convert.ToSingle(parts[7]);
                var I33 = Convert.ToSingle(parts[8]);
                var I22 = Convert.ToSingle(parts[9]);
                var V22 = Convert.ToSingle(parts[10]);
                var V33 = Convert.ToSingle(parts[11]);
                var S33 = Convert.ToSingle(parts[12]);
                var S22 = Convert.ToSingle(parts[13]);
                var Z33 = Convert.ToSingle(parts[14]);
                var Z22 = Convert.ToSingle(parts[15]);
                var r33 = Convert.ToSingle(parts[16]);
                var r22 = Convert.ToSingle(parts[17]);

                var pattern_HEA = @"^HE[0-9]{3,4}A$";
                var pattern_HEB = @"^HE[0-9]{3,4}B$";
                var pattern_HEM = @"^HE[0-9]{3,4}M$";
                var pattern_IPE = @"^IPE[0-9]{3}$";
                
                var category = "";
                if (Regex.IsMatch(name, pattern_HEA))
                {
                    category = "HEA";
                }
                else if (Regex.IsMatch(name, pattern_HEB))
                {
                    category = "HEB";
                }
                else if (Regex.IsMatch(name, pattern_HEM))
                {
                    category = "HEM";
                }
                else if (Regex.IsMatch(name, pattern_IPE))
                {
                    category = "IPE";
                }
                
                var section = new SectionIRolled(name, "", category, h, bf, tf, tw, kc, A, J, I33, I22, V33, V22, S33, S22, Z33, Z22, r33, r22);
                list.Add(section);
            }

            //section = new SectionI("UserDefined", 300, 250, 12, 10, 0.0);
            //secList.Add(section);

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
