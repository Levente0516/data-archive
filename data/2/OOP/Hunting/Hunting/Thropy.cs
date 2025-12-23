using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunting
{
    class Thropy
    {
        public readonly Animal animal;
        public readonly string place;
        public readonly string date;

        public Thropy(Animal animal, string place, string date)
        {
            this.animal = animal;
            this.place = place;
            this.date = date;
        }
    }
}
