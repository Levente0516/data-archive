using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Beandando_6
{
    public class Bill
    {
        public string name;
        public List<Product> product = new();
        public int Sum;

       public Bill(string name)
        {
            this.name = name;
            Sum = 0;
        }

        public void Add(Product p)
        {
            product.Add(p);
            Sum += p.price;
        }
    }
}
