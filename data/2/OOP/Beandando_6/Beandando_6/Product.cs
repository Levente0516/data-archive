using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Beandando_6
{
    public class Product
    {
        public int cikkszam;
        public int price;

        public Product(int c, int p)
        {
            this.cikkszam = c;
            this.price = p;
        }
    }
}
