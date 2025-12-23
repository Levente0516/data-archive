using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase
{
    class Store
    {
        public Department foods;
        public Department technical;

        public Store(string fname, string tname)
        {
            foods = new Department(fname);
            technical = new Department(tname);
        }
    }
}
