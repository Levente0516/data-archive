using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingContest
{
    public class Fisher
    {
        public readonly string name;
        private readonly List<Catch> list = new();
        public double Sum
        {
            get;
            private set;
        }
        public Fisher(string n)
        {
            name = n;
            Sum = 0.0;
        }

        public void Add(Catch catching)
        {
            list.Add(catching);
            if (catching.species == "ponty" && catching.length >= 0.5)
            {
                Sum += catching.weight;
            }
        }
    }
}
