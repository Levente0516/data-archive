using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiherContest
{
    public class Fisher
    {
        public class ExistingCatchingException : Exception { }

        public readonly string name;

        private readonly List<Catching> catchings = new();
        
        public Fisher(string name)
        {
            this.name = name;
        }

        public void Catch(DateTime time, IFish fish, double weight, Contest contest)
        {
            bool l = false;
            foreach (Catching c in catchings)
            {
                if (l = c.Time.Equals(time) && c.Fisher == this)
                {
                    break;
                }
            }

            if (l)
            {
                throw new ExistingCatchingException();
            }

            Catching catching = new(time, fish, weight, this, contest);
            catchings.Add(catching);
            contest.Check(catching);
        }

        public bool CatchedCatfish(Contest contest)
        {
            foreach(Catching c in catchings)
            {
                if (c.Fish is Catfish && c.Contest == contest)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
