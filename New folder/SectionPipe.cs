using System;
using System.Collections;
using System.Collections.Generic;
using Base_Plate_Engine.Properties;

namespace Base_Plate_Engine.Design.Sections
{
    public class SectionPipe : Section
    {
        public static IReadOnlyList<SectionPipe> Pipe;

        static SectionPipe()
        {
            var lines = Resources.Section_Pipe.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var secList = new List<SectionPipe>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                var name = parts[0];
                var od = Convert.ToSingle(parts[1]);
                var tw = Convert.ToSingle(parts[2]);

                var sec = new SectionPipe(name, od, tw)
                {
                    A = Convert.ToSingle(parts[3]),
                    J = Convert.ToSingle(parts[4]),
                    I33 = Convert.ToSingle(parts[5]),
                    I22 = Convert.ToSingle(parts[6]),
                    V22 = Convert.ToSingle(parts[7]),
                    V33 = Convert.ToSingle(parts[8]),
                    S33 = Convert.ToSingle(parts[9]),
                    S22 = Convert.ToSingle(parts[10]),
                    Z33 = Convert.ToSingle(parts[11]),
                    Z22 = Convert.ToSingle(parts[12]),
                    r33 = Convert.ToSingle(parts[13]),
                    r22 = Convert.ToSingle(parts[14])
                };

                secList.Add(sec);
            }

            Pipe = secList.ToArray();
        }


        public double od { get; }
        public double tw { get; }

        public SectionPipe(string Name, float od, float tw)
        {
            this.Name = Name;

            this.od = od;
            this.tw = tw;
        }
    }
}
