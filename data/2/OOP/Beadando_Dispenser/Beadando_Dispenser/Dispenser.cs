using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Dispenser
{
    internal class Dispenser
    {
        private readonly double max;
        private readonly double dose;
        private double act;

        public class NotEnough : Exception { };
        public Dispenser(double a, double b)
        {
            if (a < 0 || b < 0) throw new NotEnough();
            max = a;
            dose = b;
            act = 0.0;
        }
        public double Push()
        {
            return this.act -= this.dose;
        }
        public void Fill()
        {
            this.act = this.max; 
        }
        public bool IsEmpty()
        {
            if (act <= 0 ) { return true; }
            else { return false; }
        }
    }
}
