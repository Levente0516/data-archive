using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Purchase
{
    class Product
    {
        public readonly string name;
        public readonly int price;

        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public static bool Read(TextFileReader reader, out Product product)
        {
            bool l;
            reader.ReadString(out string name);
            l = reader.ReadInt(out int price);
            product = new Product(name, price);
            return l;
        }
    }
}
