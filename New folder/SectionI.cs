using System;
using System.Collections;
using System.Collections.Generic;
using Base_Plate_Engine.Design.Sections.Interfaces;
using Base_Plate_Engine.Properties;

namespace Base_Plate_Engine.Design.Sections
{
    public class SectionI : Section
    {
        public static IList<SectionI> Section;

        static SectionI()
        {
            var lines = Resources.Section_I.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var secList = new List<SectionI>();
            SectionI section;
            for (var i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                var name = parts[0];
                var h = Convert.ToSingle(parts[1]);
                var bf = Convert.ToSingle(parts[2]);
                var tf = Convert.ToSingle(parts[3]);
                var tw = Convert.ToSingle(parts[4]);
                var kc = Convert.ToSingle(parts[5]);

                section = new SectionI(name, h, bf, tf, tw, kc)
                {
                    A = Convert.ToSingle(parts[6]),
                    J = Convert.ToSingle(parts[7]),
                    I33 = Convert.ToSingle(parts[8]),
                    I22 = Convert.ToSingle(parts[9]),
                    V22 = Convert.ToSingle(parts[10]),
                    V33 = Convert.ToSingle(parts[11]),
                    S33 = Convert.ToSingle(parts[12]),
                    S22 = Convert.ToSingle(parts[13]),
                    Z33 = Convert.ToSingle(parts[14]),
                    Z22 = Convert.ToSingle(parts[15]),
                    r33 = Convert.ToSingle(parts[16]),
                    r22 = Convert.ToSingle(parts[17])
                };

                secList.Add(section);
            }

            section = new SectionI("UserDefined", 300, 250 , 12, 10, 0.0);
            secList.Add(section);
            Section = secList.ToArray();
        }

        public SectionI(string name, double h, double bf, double tf, double tw, double r)
            : base()
        {
            this.Name = name;
            this.h = h;
            this.bf = bf;
            this.tf = tf;
            this.tw = tw;
            this.r = r;

            d1 = h - 2 * tf;


            A = 2 * tf * bf + (h - 2 * tf) * tw;

            J = 0;

            I33 = (bf * (float) Math.Pow(h, 3) - (bf - tw) * (float) Math.Pow((h - 2 * tf), 3)) / 12;
            I22 = 0;

            V22 = 0;
            V33 = 0;

            S33 = I33 / (h / 2);
            S22 = I22 / (bf / 2);

            Z33 = 0;
            Z22 = 0;

            r33 = 0;
            r22 = 0;
        }

        
        public int Compare(object x, object y)
        {
            var Sec1 = (SectionI)x;
            var Sec2 = (SectionI)y;

            return new CaseInsensitiveComparer().Compare(Sec1.Name, Sec2.Name);

            //string PreNo1,PreNo2;
            //int No1,No2;
            //string PostNo1 = string.Empty;
            //string PostNo2 = string.Empty;
            //System.Text.RegularExpressions.Regex regHE = new System.Text.RegularExpressions.Regex("HE");
            //System.Text.RegularExpressions.Regex regIPE = new System.Text.RegularExpressions.Regex("IPE");
            //System.Text.RegularExpressions.Regex regNo = new System.Text.RegularExpressions.Regex("\\d+");

            //if (Sec1.Name == "UserDefined" || Sec2.Name == "UserDefined")
            //    return new CaseInsensitiveComparer().Compare(Sec1.Name, Sec2.Name);

            //if (regHE.Match(Sec1.Name).Success)
            //    PreNo1 = regHE.Match(Sec1.Name).Value;
            //else
            //    PreNo1 = "";

            //if (regHE.Match(Sec2.Name).Success)
            //    PreNo2 = regHE.Match(Sec2.Name).Value;
            //else
            //    PreNo2 = "";

            //if (regIPE.Match(Sec1.Name).Success)
            //    PreNo1 = regIPE.Match(Sec1.Name).Value;
            //if (regIPE.Match(Sec2.Name).Success)
            //    PreNo2 = regIPE.Match(Sec2.Name).Value;

            //No1 = Convert.ToInt32(regNo.Match(Sec1.Name).Value);
            //No2 = Convert.ToInt32(regNo.Match(Sec2.Name).Value);

            //if (PreNo1 == "HE")
            //    PostNo1 = Sec1.Name.Substring(Sec1.Name.Length - 1, 1);
            //if (PreNo2 == "HE")
            //    PostNo2 = Sec2.Name.Substring(Sec2.Name.Length - 1, 1);

            //if (PreNo1 == "HE" && PreNo2 == "IPE")
            //    return -1;
            //else if (PreNo1 == "IPE" && PreNo2 == "HE")
            //    return 1;
            //else if (PreNo1 == "IPE" && PreNo2 == "IPE")
            //    return new CaseInsensitiveComparer().Compare(No1, No2);
            //else if (PreNo1 == "HE" && PreNo2 == "HE")
            //    if (No1 == No2)
            //        return new CaseInsensitiveComparer().Compare(PostNo1, PostNo2);
            //    else
            //        return new CaseInsensitiveComparer().Compare(No1, No2);

            //return new CaseInsensitiveComparer().Compare(Sec1.Name, Sec2.Name);
        }


        public double d { get; }
        
        public double h { get; }
        
        public double d1 { get; }
        
        public double bf { get; }
        
        public double tf { get; }
        
        public double tw { get; }
        
        public double r { get; }
    }
}
