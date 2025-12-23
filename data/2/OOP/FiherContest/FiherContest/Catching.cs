using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiherContest
{
    public class Catching
    {
        public DateTime Time { get;  }

        private readonly double weight;

        public IFish Fish { get; }

        public Contest Contest { get; }

        public Fisher Fisher { get; }

        public Catching(DateTime time, IFish fish, double weight, Fisher fisher, Contest contest)
        {
            Time = time;
            Fish = fish;
            this.weight = weight;
            Fisher = fisher;
            Contest = contest;
        }

        public double Value()
        {
            return weight * Fish.Multiplier();
        }
    }
}
