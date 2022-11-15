using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Plate_Engine.Design.Sections
{
    public class Section: ISection
    {
        public Section()
        {

        }

        public string Name { get; }
        public double A { get; }
        public double J { get; }
        public double I33 { get; }
        public double I22 { get; }
        public double V22 { get; }
        public double V33 { get; }
        public double S33 { get; }
        public double S22 { get; }
        public double Z33 { get; }
        public double Z22 { get; }
        public double r33 { get; }
        public double r22 { get; }
        public double Premeter { get; }
        public bool IsCompact { get; }
        int ISection.Compare(object x, object y)
        {
            throw new NotImplementedException();
        }

        int IComparer.Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}
