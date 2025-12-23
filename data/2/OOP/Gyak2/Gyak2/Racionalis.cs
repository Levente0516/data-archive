using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak2
{
    internal class Racionalis
    {
        public class NullDenominator : Exception { };

        public class NullDivision : Exception { };

        private readonly int n;
        private readonly int d;

        public Racionalis(int u = 0, int v = 1)
        {
            if (v == 0) throw new NullDenominator();
            n = u; d = v;
        }

        public static Racionalis operator + (Racionalis a, Racionalis b)
        {
            return new Racionalis(a.n * b.d + a.d * b.n, a.d * b.d);
        }
        public static Racionalis operator - (Racionalis a, Racionalis b)
        {
            return new Racionalis(a.n * b.d - a.d * b.n, a.d * b.d);
        }
        public static Racionalis operator * (Racionalis a, Racionalis b)
        {
            return new Racionalis(a.n * b.n, a.d * b.d);
        }
        public static Racionalis operator / (Racionalis a, Racionalis b)
        {
            if (0 == b.n) throw new NullDivision();
            return new Racionalis(a.n * b.d - a.d * b.n, a.d * b.d);
        }
        public override string ToString()
        {
            return ("(" + n.ToString() + "," + d.ToString() + ")");
        }
    }
}
