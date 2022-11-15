using Base_Plate_Engine.Common.Section.Shapes;
using Mono_Base_Plate.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Base_Plate.Factory
{
    public static class SectionPipeFactory
    {
        public static ImmutableArray<SectionPipe> Items { get; }

        static SectionPipeFactory()
        {
            var lines = Resources.Section_Pipe.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<SectionPipe>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                var name = parts[0];
                var od = Convert.ToSingle(parts[1]);
                var tw = Convert.ToSingle(parts[2]);
                var A = Convert.ToSingle(parts[3]);
                var J = Convert.ToSingle(parts[4]);
                var Ix = Convert.ToSingle(parts[5]);
                var Iy = Convert.ToSingle(parts[6]);
                var V22 = Convert.ToSingle(parts[7]);
                var V33 = Convert.ToSingle(parts[8]);
                var Sx = Convert.ToSingle(parts[9]);
                var Sy = Convert.ToSingle(parts[10]);
                var Zx = Convert.ToSingle(parts[11]);
                var Zy = Convert.ToSingle(parts[12]);
                var rx = Convert.ToSingle(parts[13]);
                var ry = Convert.ToSingle(parts[14]);

                var sec = new SectionPipe(name, od, tw, A, J, Ix, Iy, V22, V33, Sx, Sy, Zx, Zy, rx, ry);

                list.Add(sec);
            }

            Items = ImmutableArray.Create(list.ToArray());
        }
    }
}
