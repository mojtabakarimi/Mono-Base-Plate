using System.Collections;
using System.Collections.Generic;

namespace Mono_Base_Plate.CSI.Structs
{
    public struct Points: IEnumerable<Points>
    {
        private static List<Points> _pointList = new List<Points>();

        public Points this[int index]
        {
            get => _pointList[index];
            set => _pointList.Insert(index, value);
        }

        public IEnumerator<Points> GetEnumerator()
        {
            return _pointList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string Name { get; }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Points(string name, double x, double y, double z)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
