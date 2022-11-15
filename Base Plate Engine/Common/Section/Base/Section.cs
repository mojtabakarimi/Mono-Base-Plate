using System;
using System.Collections;
using Base_Plate_Engine.Common.Section.Interfaces;
using Newtonsoft.Json;

namespace Base_Plate_Engine.Common.Section.Base
{
    public abstract class Section : ISection, IComparer
    {
        protected Section(
            string name,
            string category,
            string library,
            double A,
            double J,
            double Ix,
            double Iy,
            double Vy,
            double Vx,
            double Sx,
            double Sy,
            double Zx,
            double Zy,
            double rx,
            double ry)
        {
            Name = name;

            Category = category;
            Library = library;

            this.A = A;
            this.J = J;
            this.Ix = Ix;
            this.Iy = Iy;
            this.Vy = Vy;
            this.Vx = Vx;
            this.Sx = Sx;
            this.Sy = Sy;
            this.Zx = Zx;
            this.Zy = Zy;
            this.rx = rx;
            this.ry = ry;
        }
        public string Name { get; }

        public string Library { get; }

        public string Category { get; }


        /// <summary>
        /// Cross-section area
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Torsional constant
        /// </summary>
        public double J { get; }

        /// <summary>
        /// Moment of inertia about x axis, mm4
        /// </summary>
        public double Ix { get; }

        /// <summary>
        /// Moment of inertia about y axis, mm4
        /// </summary>
        public double Iy { get;  }

        /// <summary>
        /// Shear area in y direction, mm3
        /// </summary>
        public double Vy { get; }

        /// <summary>
        /// Shear area in x direction, mm3
        /// </summary>
        public double Vx { get; }

        /// <summary>
        /// Section modulus about x axis, mm3
        /// </summary>
        public double Sx { get; }

        /// <summary>
        /// Section modulus about y axis, mm3
        /// </summary>
        public double Sy { get; }

        /// <summary>
        /// Plastic modulus about x axis, mm3
        /// </summary>
        public double Zx { get; }

        /// <summary>
        /// Plastic modulus about y axis, mm3
        /// </summary>
        public double Zy { get; }

        /// <summary>
        /// Radius of gyration, x, mm
        /// </summary>
        public double rx { get; }

        /// <summary>
        /// Radius of gyration, y, mm
        /// </summary>
        public double ry { get; }

        [JsonIgnore]
        public abstract double Perimeter { get; }

        public abstract bool IsCompact { get; }

        
        public int Compare(object x, object y)
        {
            if (!(x is Section section1) || !(y is Section section2))
            {
                throw new NullReferenceException();
            }

            return string.CompareOrdinal(section1.Name, section2.Name);
            //return new CaseInsensitiveComparer().Compare(section1.Name, section2.Name);
        }
    }
}
