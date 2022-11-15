using System;
using System.Collections;
using Newtonsoft.Json;

namespace Base_Plate_Engine.Design.Sections
{
    public interface ISection : IComparer
    {
        string Name { get; }

        double A { get; }

        double J { get; }

        double I33 { get; }

        double I22 { get; }

        double V22 { get; }

        double V33 { get; }

        double S33 { get; }

        double S22 { get; }

        double Z33 { get; }

        double Z22 { get; }

        double r33 { get; }

        double r22 { get; }

        double Premeter { get; }

        bool IsCompact { get; }
        

        int Compare(object x, object y);
    }
}
