using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak1
{
    internal class Point
    {
        private readonly double x;
        private readonly double y;

        public Point(double a, double b) { x = a; y = b; }

        public static double Distance(Point p, Point q)
        {
            return Math.Sqrt(Math.Pow(p.x - q.x, 2) + Math.Pow(p.y - q.y, 2));      
        }
    }
}
