using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mono_Base_Plate.Save;

public class Section
{
    public double r { get; set; }
    
    public double kc { get; set; }
    
    public double h_2c { get; set; }
    
    public string IsCompact { get; set; }
    
    public double d { get; set; }
    
    public double h { get; set; }
    
    public double d1 { get; set; }
    
    public double bf { get; set; }
    
    public double tf { get; set; }
    
    public double tw { get; set; }
    
    public string Name { get; set; }
    
    public string Library { get; set; }
    
    public string Category { get; set; }
    
    public double A { get; set; }
    
    public double J { get; set; }

    public double Ix { get; set; }

    public double Iy { get; set; }

    public double Vy { get; set; }

    public double Vx { get; set; }

    public double Sx { get; set; }

    public double Sy { get; set; }

    public double Zx { get; set; }

    public double Zy { get; set; }

    public double rx { get; set; }

    public double ry { get; set; }
}

public class BasePlate
{
    public string N { get; set; }

    public string B { get; set; }
}

public class Pedestal
{
    public double Np { get; set; }
    
    public double Bp { get; set; }
    
    public double Hp { get; set; }

    public double Cover { get; set; }

}

public class BasePlateEccentricity
{
    public double Necc { get; set; }
    
    public double Becc { get; set; }
}

public class RodsDistance
{
    public double a_N { get; set; }
    
    public double a_B { get; set; }
}

public class LoadEccentricity
{
    public int l_N { get; set; }
    
    public int l_B { get; set; }
}

public class ConcreteMaterial
{
    public double fc { get; set; }
    
    public double fyr { get; set; }
    
    public double fyrs { get; set; }
}

public class SteelMaterial
{
    [JsonProperty("fy")]
    public double fy { get; set; }

    [JsonProperty("E")]
    public double E { get; set; } = 200_000;
}

public class BoltMaterial
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("fyb")]
    public double fyb { get; set; }

    [JsonProperty("fub")]
    public double fub { get; set; }
}

public class Bolt
{
    public int nbN { get; set; }

    public int nbB { get; set; }

    public string BoltName { get; set; }

    public int ThreadsExcluded { get; set; }
}

public class Rod
{
    public int nrN { get; set; }

    public int nrB { get; set; }

    public int dr { get; set; }
}

public class RebarMaterial
{
    public int drs { get; set; }

    public int nrs { get; set; }

    public string rsS { get; set; }
}

public class Stiffener
{
    public StiffenerType Type { get; set; }

    public double hs { get; set; }
}

public enum StiffenerType
{
    Type1 = 0,
    Type2 = 1, 
    Type3 = 2, 
    Type4 = 3, 
    Type5 = 4, 
    Type6 = 5,
}

public class ShearKeySection
{
    public string Type { get; set; }

    public string Profile { get; set; }

    public string Orientation { get; set; }
}

public class ShearKeyProperty
{
    public string ShearKeyHeight { get; set; }

    public ShearKeySection ShearKeySection { get; set; }
}

public class ShearResisting
{
    public string Type { get; set; }

    public ShearKeyProperty Property { get; set; }
}

public class WeldProperty
{
    public string WeldUltimateStregth { get; set; }

    public double WeldCheckCoeff { get; set; }

    public int WeldSize { get; set; }
}

public class Weld
{
    public string Type { get; set; }

    public WeldProperty Property { get; set; }
}

public class Load
{
    public string Name { get; set; }

    public double Vu { get; set; }

    public double Pu { get; set; }

    public double Mu { get; set; }
}

public class SaveData
{
    public string ApplicationName { get; set; }

    public string Date { get; set; }

    public string Time { get; set; }

    public string Version { get; set; }

    public string CompanyName { get; set; }

    public string ProjectName { get; set; }

    public string EngineerName { get; set; }

    public string Description { get; set; }

    public string Notes { get; set; }

    public Section Section { get; set; }

    public BasePlate BasePlate { get; set; }

    public Pedestal Pedestal { get; set; }

    public BasePlateEccentricity BasePlateEccentricity { get; set; }

    public RodsDistance RodsDistance { get; set; }

    public LoadEccentricity LoadEccentricity { get; set; }

    public ConcreteMaterial ConcreteMaterial { get; set; }

    public SteelMaterial ColumnSteelMaterial { get; set; }

    public SteelMaterial PlateSteelMaterial { get; set; }

    public BoltMaterial BoltMaterial { get; set; }

    public Bolt Bolt { get; set; }

    public Rod Rod { get; set; }

    public RebarMaterial RebarMaterial { get; set; }

    public Stiffener Stiffener { get; set; }

    public int BuiltUpGroutPad { get; set; }

    public double GroutThickness { get; set; }

    public ShearResisting ShearResisting { get; set; }

    public Weld Weld { get; set; }

    public List<Load> Loads { get; set; }

    public string DesignMethod { get; set; }
}