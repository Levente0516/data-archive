using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Beandando_6
{
    public class ReadIn
    {

        public TextFileReader reader;
        public ReadIn(string fname)
        {
            reader = new TextFileReader(fname);
        }
        public Bill Read()
        {
            Bill bill = null;

            if (reader.ReadLine(out string line))
            {
                string[] parts = line.Split(' ');

                bill = new Bill(parts[0]);

                for (int i = 1; i < parts.Length; i += 2)
                {
                    bill.Add(new Product(int.Parse(parts[i]), int.Parse(parts[i + 1])));
                }
            }

            return bill;
        }
    }
}
