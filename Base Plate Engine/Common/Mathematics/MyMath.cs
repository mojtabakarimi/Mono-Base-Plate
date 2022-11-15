using System;
using System.Collections.Generic;
using System.Linq;

namespace Base_Plate_Engine.Common.Mathematics
{
    public static class MyMath
    {
        public static double RoundUpTo(this double value, double roundTo)
        {
            return Math.Ceiling(value / roundTo) * roundTo;
        }

        public static decimal RoundUpTo(decimal value, decimal roundTo)
        {
            return Math.Ceiling(value / roundTo) * roundTo;
        }

        public static decimal RoundDownTo(decimal value, decimal roundTo)
        {
            return Math.Floor(value / roundTo) * roundTo;
        }

        #region Max
        public static decimal Max(params decimal[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                if (result < values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        public static double Max(params double[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                if (result < values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        public static float Max(params float[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                if (result < values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        public static int Max(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];

            for (var i = 1; i < values.Length; i++)
            {
                if (result < values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        #endregion

        #region Min

        public static decimal Min(params decimal[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];
            for (var i0 = 1; i0 < values.Length; i0++)
            {
                if (result > values[i0])
                {
                    result = values[i0];
                }
            }
            return result;
        }

        public static double Min(params double[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                if (result > values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        public static float Min(params float[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                if (result > values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        public static int Min(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("At least one item should be passed");
            }

            var result = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                if (result > values[i])
                {
                    result = values[i];
                }
            }
            return result;
        }

        #endregion

        #region Geometry

        public static double PointToLineDistance(Point2D point, Line2D line)
        {
            return Math.Abs(line.ParamA * point.X + line.ParamB * point.Y + line.ParamC) / Math.Sqrt(Math.Pow(line.ParamA, 2) + Math.Pow(line.ParamB, 2));
        }

        public static double PointToLineDistance(Point2D point, Line2D line, ref Point2D thePoint)
        {
            thePoint.X = (line.ParamB * (line.ParamB * point.X - line.ParamA * point.Y) - line.ParamA * line.ParamC) / (Math.Pow(line.ParamA, 2) + Math.Pow(line.ParamB, 2));
            thePoint.Y = (line.ParamA * (-line.ParamB * point.X + line.ParamA * point.Y) - line.ParamB * line.ParamC) / (Math.Pow(line.ParamA, 2) + Math.Pow(line.ParamB, 2));

            return Math.Abs(line.ParamA * point.X + line.ParamB * point.Y + line.ParamC) / Math.Sqrt(Math.Pow(line.ParamA, 2) + Math.Pow(line.ParamB, 2));
        }

        /// <summary>
        /// ax+by+c=0
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Line2D GetLineFromPoints(Point2D point1, Point2D point2)
        {
            Line2D Line;

            var x1 = point1.X;
            var y1 = point1.Y;
            var x2 = point2.X;
            var y2 = point2.Y;

            if (x2 == x1)
            {
                Line = new Line2D(1,0,-x1,Line2D.Situations.ParallelY);
            }
            else if (y1 == y2)
            {
                Line = new Line2D(0, 1, -y1, Line2D.Situations.ParallelX);
            }
            else
            {
                var m = (y2 - y1) / (x2 - x1);
                Line = new Line2D(-m, 1, m * x1 - y1, Line2D.Situations.Normal);
            }

            return Line;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <returns></returns>
        public static Point2D LineIntersection(Line2D line1, Line2D line2)
        {
            Point2D point;

            if (line1.Situation == Line2D.Situations.Normal && line2.Situation == Line2D.Situations.Normal)
            {
                line1.ParamB = line1.ParamB / line1.ParamA;
                line1.ParamC = line1.ParamC / line1.ParamA;
                line1.ParamA = line1.ParamA / line1.ParamA;

                line2.ParamB = line2.ParamB / line2.ParamA;
                line2.ParamC = line2.ParamC / line2.ParamA;
                line2.ParamA = line2.ParamA / line2.ParamA;

                var Y = (line2.ParamC - line1.ParamC) / (line1.ParamB - line2.ParamB);
                var X = -line2.ParamB * Y - line2.ParamC;

                point = new Point2D(X, Y);
            }
            else
            {
                if (line1.Situation == Line2D.Situations.Normal)
                {
                    double X, Y;

                    line1.ParamB = line1.ParamB / line1.ParamA;
                    line1.ParamC = line1.ParamC / line1.ParamA;
                    line1.ParamA = line1.ParamA / line1.ParamA;

                    line2.ParamB = line2.ParamB / line2.ParamB;
                    line2.ParamC = line2.ParamC / line2.ParamB;

                    X = (line2.ParamC - line1.ParamC) / line1.ParamA;
                    Y = -line2.ParamC;

                    point = new Point2D(X, Y);
                }
                else if (line2.Situation == Line2D.Situations.Normal)
                {
                    double X, Y;

                    line1.ParamB = line1.ParamB / line1.ParamB;
                    line1.ParamC = line1.ParamC / line1.ParamB;

                    line2.ParamB = line2.ParamB / line2.ParamA;
                    line2.ParamC = line2.ParamC / line2.ParamA;
                    line2.ParamA = line2.ParamA / line2.ParamA;

                    Y = -line1.ParamC;
                    X = -line2.ParamB * Y;

                    point = new Point2D(X, Y);
                }
                else if (line1.Situation == Line2D.Situations.ParallelX && line2.Situation == Line2D.Situations.ParallelY)
                {
                    point = new Point2D(double.NaN, double.NaN);      //need to be fixed!!
                }
                else
                {
                    point = new Point2D(double.NaN , double.NaN);
                }
            }

            return point;
        }

        #endregion

        public static double Interpolate(double x, IReadOnlyList<double> xx, IReadOnlyList<double> yy)
        {
            if (xx == null || double.IsInfinity(x) || double.IsNaN(x))
            {
                throw new ArgumentException();
            }

            if (yy == null || xx.Count < 2 || yy == null || xx.Count != yy.Count
                || xx.Any(p => double.IsInfinity(p) || double.IsNaN(p))
                || yy.Any(p => double.IsInfinity(p) || double.IsNaN(p)))
            {
                throw new ArgumentException();
            }
            
            for (var i = 0; i < xx.Count - 1; i++)
            {
                if (xx[i] >= xx[i + 1])
                {
                    throw new ArgumentException();
                }
            }

            if (x < xx.First())
            {
                return yy.First();
            }

            if (x >= xx.Last())
            {
                return yy.Last();
            }

            for (var i = 0; i < xx.Count - 1; i++)
            {
                if (x >= xx[i] && x < xx[i + 1])
                {
                    return yy[i] + (yy[i + 1] - yy[i]) / (xx[i + 1] - xx[i]) * (x - xx[i]);
                }
            }

            throw new ArgumentException();
        }

        #region Define Class

        public class Point2D
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point2D()
            {
            }

            public Point2D(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }

        public class Line2D
        {   //ax+by+c=0
            public double ParamA { get; set; }

            public double ParamB { get; set; }

            public double ParamC { get; set; }

            public Situations Situation { get; }

            public Line2D(double paramA, double paramB, double paramC, Situations Situation)
            {
                const double tolerance = 0.00000001;
                if (Math.Abs(paramA) < tolerance && Math.Abs(paramB) < tolerance)
                {
                    throw new ArgumentNullException("\"paramA\" and \"paramB\" cant be zero together!");
                }

                ParamA = paramA;
                ParamB = paramB;
                ParamC = paramC;
                this.Situation = Situation;
            }

            public enum Situations
            {
                NotSet = 0,
                Normal = 1,
                ParallelX = 2,
                ParallelY = 3
            }

        }

        #endregion

    }
}
