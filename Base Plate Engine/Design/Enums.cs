namespace Base_Plate_Engine.Design
{
    public enum DesignMethod
    {
        ASCE7_LRFD,
        ASCE7_ASD
    }

    public enum BasePlateDesign
    {
        AISC360_10,
        AISC360_05
    }

    public enum AnchorBoltAndPedestalDesignMethod
    {
        ACI318_14,
        ACI318_11,
        ACI318_08
    }

    public enum PressureDistribution
    {
        Rectangular,
        Triangular
    }

    public enum ShearResistance
    {
        ShearKey,
        AnchorBolt
    }

    public enum WeldType
    {
        CJP,
        Fillet
    }
}
