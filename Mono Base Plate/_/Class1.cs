using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base_Plate_Engine.Common.Section.Interfaces;
using Base_Plate_Engine.Common.Section.Shapes;

namespace Mono_Base_Plate.Class
{
    public class BasePlateLoad
    {
        public double T { get; set; }
        public double V { get; set; }
        public double M { get; set; }
        public string Name { get; set; }
    }

    public class Weld
    {
        public string Type { get; set; }
        public string UltimateStrength { get; set; }
        public string CheckCoefficient { get; set; }
        public string Size { get; set; }
    }

    public class ShearResisting
    {
        public string Type { get; set; }
        public string Height { get; set; }
        public string Section { get; set; }
    }

    public class SaveModel
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public string ProgramVersion { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string EngineerName { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }


        public SectionI Section { get; set; }
        public double N { get; set; }
        public double B { get; set; }

        public double Np { get; set; }
        public double Bp { get; set; }
        public double Hp { get; set; }
        public double Cover { get; set; }

        public double Necc { get; set; }
        public double Becc { get; set; }

        public double a_N { get; set; }
        public double a_B { get; set; }

        public double l_N { get; set; }
        public double l_B { get; set; }

        public double fc { get; set; }
        public double fyr { get; set; }
        public double fyrs { get; set; }
        public double fyp { get; set; }
        public double fyc { get; set; }
        public double fyb { get; set; }
        public double fub { get; set; }

        public int Stiffener { get; set; }
        public double hs { get; set; }
        public bool ThreadsExcluded { get; set; }
        public bool BuiltUpGroutPad { get; set; }
        public double GroutThickness { get; set; }

        public bool ShearResisting { get; set; }
        public double ShearKeyHeight { get; set; }
        public ISection ShearKeySection { get; set; }

        public string WeldType { get; set; }
        public double WeldUltimateStregth { get; set; }
        public double WeldCheckCoeff { get; set; }
        public double WeldSize { get; set; }


        public int nbN { get; set; }
        public int nbB { get; set; }
        public string Bolt { get; set; }
        public int nrN { get; set; }
        public int nrB { get; set; }
        public int dr { get; set; }
        public int drs { get; set; }
        public int nrs { get; set; }
        public double rsS { get; set; }


        public List<Base_Plate_Engine.Design.BasePlateLoad> Loading { get; set; }
        public string DesignMethod { get; set; }
    }
}
