using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak1
{
    internal class Circle
    {
        public class WrongRadiusException : Exception {}

        private readonly Point c;
        private readonly double r;

        public Circle(Point c, double r)
        {
            if (r < 0) throw new WrongRadiusException();
            this.c = c; this.r = r;
        }

        public bool Contains(Point p)
        {
            return Point.Distance(c,p) <= r;
        }
    }
}
