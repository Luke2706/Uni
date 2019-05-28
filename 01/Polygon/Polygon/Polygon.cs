using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Point
            Point.MaxX = 100;
            Point.MaxY = 100;
            Point myPoint1 = new Point(2, 2);
            Point myPoint2 = new Point(-4, -4);
            myPoint2 = -myPoint2;
            myPoint1 *= 2;
            if (myPoint2 == myPoint1)
            {
                Console.WriteLine("identical points");
            }
            // Test Polygon
            Polygon myLine = new Polygon(new Point(2, 1), new Point(2, 2),
                new Point(3, 3));
            myLine[0] = new Point(1, 1);
            Console.WriteLine("polygon points: ");
            for (int i = 0; i < myLine.NumberPoints; i++)
            {
                Console.WriteLine(myLine[i]);
            }
            Console.WriteLine($"Length Polygon: {(double)myLine}");
            // Test constructor Point: throws ArgumentOutOfException
            Point myPoint3 = new Point(200, 200);
        }
    }

    class Point
    {
        private int xPoint;
        private int yPoint;
        public static int MaxX;
        public static int MaxY;

        /// <summary>
        /// Standard constructor for creating a 'point' 
        /// </summary>
        /// <param name="x">xPoint coordinate </param>
        /// <param name="y">yPoint coordinate</param>
        public Point(int x, int y)
        {
            //Using the checkrange method to verify the 'right' range of the coordinates
            this.xPoint = CheckRange(x, MaxX);
            this.yPoint = CheckRange(y, MaxY);

        }

        /// <summary>
        /// Verify if the values are right
        /// </summary>
        /// <param name="value">given value, e.g. the xPoint coordinate</param>
        /// <param name="maxValue">max. value for something, e.g. the max value for xPoint</param>
        /// <returns>the value if its valid</returns>
        public static int CheckRange(int value, int maxValue)
        {
            // Throw a ArgumentOutOfRangeException if given value is not in the given range
            if (-maxValue > value || value > maxValue) throw new ArgumentOutOfRangeException("Punkt außerhalb des gueltigen Bereichs");
            return value;
        }


        public static Point operator -(Point point)
        {
            return point * -1; //using the * operator of Point for changing the sign 
        }

        public static Point operator *(Point point, int factor)
        {
            return new Point (point.xPoint * factor,point.yPoint * factor );
            //returns the new points multiplicated with the given factor 

        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.xPoint == p2.xPoint && p1.yPoint == p2.yPoint;
            //checks if the coordinates of 2 points are equal 
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);//uses the == method/operator and inverts it
        }

        /// <summary>
        /// special to String method for creating the required string
        /// </summary>
        /// <returns>returns a specify string</returns>
        public override string ToString()
        {
            return $" xPoint: {this.xPoint}  yPoint: {this.yPoint}";
        }

        /// <summary>
        /// Method to calculate the distance bet 2 Points 
        /// </summary>
        /// <param name="point">given point object</param>
        /// <returns>the calculated distance of a point</returns>
        public double Distance(Point point)
        {
            int dx = point.xPoint - xPoint;
            int dy = point.yPoint - yPoint;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    class Polygon
    {
        private Point[] points;

        /// <summary>
        /// Standard constructor for creating a polygon with at least 2 points
        /// </summary>
        /// <param name="p1">1st point </param>
        /// <param name="p2">2nd point</param>
        /// <param name="points">an array with a unspecified amount of points</param>
        public Polygon(Point p1, Point p2, params Point[] points)
        {
            this.points = new Point[2 + points.Length];
            this.points[0] = p1;
            this.points[1] = p2;
            for (int i = 0; i < points.Length; i++)
            {
                this.points[i + 2] = points[i];
            }
        }

        /// <summary>
        /// Indexer for indexing the points in the polygon
        /// </summary>
        /// <param name="index">index for the array</param>
        /// <returns></returns>
        public Point this[int index]
        {
            get { return points[index]; }
            set { points[index] = value; }
        }

        /// <summary>
        /// get-only property for the length of a polygon array
        /// </summary>
        public int NumberPoints
        {
            get { return points.Length; }
        }

        /// <summary>
        /// explicit conversion of a polygon to a double which represent the perimeter 
        /// </summary>
        /// <param name="poly">the given polygon</param>
        public static explicit operator double(Polygon poly)
        {
            double result = 0.0;
            for (int i = 0; i < poly.points.Length - 1; i++)
            {
                result += poly.points[i].Distance(poly.points[i + 1]);
            }

            result += poly.points[poly.points.Length - 1].Distance(poly.points[0]);
            return result;
        }

    }
}
