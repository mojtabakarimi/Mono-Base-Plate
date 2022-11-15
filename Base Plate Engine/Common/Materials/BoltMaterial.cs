using System;
using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Common.Materials
{
    public sealed class BoltMaterial : Material
    {
        public string Name { get; }

        public string Category { get; }

        /// <summary>
        /// Ultimate 
        /// </summary>
        public double Fu { get; }

        /// <summary>
        /// Nominal Shear Strength in Bearing-Type Connections
        /// </summary>
        public double Fnt { get; }

        /// <summary>
        /// Nominal Tensile Strength
        /// </summary>
        public double Fnv { get; }

        /// <summary>
        /// Is this material is a user defined material
        /// </summary>
        public bool UserDefined { get; }

        public bool Excluded { get; }

        public BoltMaterial(string name, string category, double Fu, bool excluded, bool userDefined)
        {
            if (Fu <= 0)
            {
                throw new Exception("Not valid parameters for bolt material");
            }

            Name = name;
            Category = category;
            UserDefined = userDefined;
            this.Excluded = excluded;
            this.Fu = Fu;

            Fnt = 0.75 * Fu;
            Fnv = (excluded ? 0.563 : 0.45) * Fu;       //TODO: to be checked!
        }

        public BoltMaterial(string name, string category, double Fu, double Fnt, double Fnv, bool excluded, bool userDefined)
        {
            if (Fu <= 0 || Fnt <= 0 || Fnv <= 0)
            {
                throw new Exception("Not valid parameters for bolt material");
            }

            Name = name;
            Category = category;
            UserDefined = userDefined;
            this.Excluded = excluded;

            this.Fu = Fu;

            this.Fnt = Fnt;
            this.Fnv = Fnv;
        }
    }

    //public class BoltMaterial : Material
    //{
    //    public static IList<BoltMaterial> List;

    //    static BoltMaterial()
    //    {
    //        List = new List<BoltMaterial>
    //        {
    //            new BoltMaterial("A325", "ASTM", 800, 620, 469, 372, false),
    //            new BoltMaterial("A490", "ASTM", 1000, 780, 579, 469, false),
    //            new BoltMaterial("8.8", "DIN", 800, false), 
    //            new BoltMaterial("10.9", "DIN", 1000, false)
    //        };
    //    }

    //    private string name;

    //    public string Name
    //    {
    //        get => name;
    //        set
    //        {
    //            if (!UserDefined)
    //            {
    //                return;
    //            }

    //            name = value;
    //        }
    //    }

    //    public string Category { get; set; }

    //    /// <summary>
    //    /// Ultimate 
    //    /// </summary>
    //    public double Fu { get; }

    //    /// <summary>
    //    /// Nominal Shear Strength in Bearing-Type Connections
    //    /// </summary>
    //    public double Fnt { get; }

    //    /// <summary>
    //    /// Nominal Tensile Strength, threads are excluded (e) from shear planes
    //    /// </summary>
    //    public double Fnv_e { get; }

    //    /// <summary>
    //    /// Nominal Tensile Strength, threads are not excluded (ne) from shear planes
    //    /// </summary>
    //    public double Fnv_ne { get; }

    //    /// <summary>
    //    /// Nominal Tensile Strength
    //    /// </summary>
    //    public double Fnv(bool excluded) => excluded ? Fnv_e : Fnv_ne;

    //    /// <summary>
    //    /// Is this material is a user defined material
    //    /// </summary>
    //    public bool UserDefined { get; }

    //    public BoltMaterial(string name, string category, double Fu, bool userDefined)
    //    {
    //        if (Fu <= 0)
    //        {
    //            throw new Exception("Not valid parameters for bolt material");
    //        }

    //        Name = name;
    //        Category = category;
    //        UserDefined = userDefined;
    //        this.Fu = Fu;

    //        Fnt = 0.75 * Fu;
    //        Fnv_ne = 0.45 * Fu;
    //        Fnv_e = 0.563 * Fu;
    //    }

    //    public BoltMaterial(string name, string category, double Fu, double Fnt, double Fnv_excluded, double Fnv_notExcluded, bool userDefined)
    //    {
    //        if (Fu <= 0 || Fnt <= 0 || Fnv_excluded <= 0 || Fnv_notExcluded <= 0)
    //        {
    //            throw new Exception("Not valid parameters for bolt material");
    //        }

    //        Name = name;
    //        Category = category;
    //        UserDefined = userDefined;
    //        this.Fu = Fu;

    //        this.Fnt = Fnt;
    //        Fnv_e = Fnv_excluded;
    //        Fnv_ne = Fnv_notExcluded;
    //    }
    //}
}