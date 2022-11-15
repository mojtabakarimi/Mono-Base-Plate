using System;

namespace Base_Plate_Engine.Design
{
    public class BasePlateLoad
    {
        const double TOLERANCE = 0.00001;

        public BasePlateLoad(string name, double Pu, double Vux, double Muy)
        {
            Name = name;
            this.Pu = Pu;
            this.Vux = Vux;
            this.Muy = Muy;
        }
        
        public string Name { get; }

        public double Pu { get; }
        public double Muy { get;}
        public double Vux { get; }

        public static BasePlateLoad operator *(BasePlateLoad basePlateLoad, double Value)
        {
            return new BasePlateLoad(basePlateLoad.Name, basePlateLoad.Pu * Value, basePlateLoad.Vux * Value ,basePlateLoad.Muy * Value);
        }

        public double eu
        {
            get
            {
                if (Math.Abs(Pu) < TOLERANCE)
                {
                    return double.MaxValue;
                }

                return Muy / Pu;
            }
        }

        public bool IsWithoutMoment => Math.Abs(Muy) < TOLERANCE;

        public BasePlateLoad Clone()
        {
            return (BasePlateLoad)MemberwiseClone();
        }

    }
}
