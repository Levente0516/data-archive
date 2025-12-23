using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiherContest
{
    public class Contest
    {
        public class AlreadyRegistratedExceptin : Exception { }

        public class FisherNotRegistratedExceptin : Exception { }

        public class CatchingAlreadyChecked : Exception { }

        private readonly Organization org;
        public readonly string place;

        public DateTime Start { get; }

        private readonly List<Fisher> fishers = new();
        private readonly List<Catching> catchings = new();

        public Contest(Organization org, string place, DateTime start)
        {
            this.org = org;
            this.place = place;
            Start = start;
        }

        public void SignUp(Fisher fisher)
        {
            if (!org.Member(fisher))
            {
                throw new FisherNotRegistratedExceptin();
            }

            if (fishers.Contains(fisher))
            {
                throw new AlreadyRegistratedExceptin();
            }

            fishers.Add(fisher);
        }

        public void Check(Catching catching)
        {
            if(catchings.Contains(catching))
            {
                throw new CatchingAlreadyChecked();
            }

            catchings.Add(catching);
        }

        public double TotalAmount()
        {
            double s = 0;

            foreach (Catching c in catchings)
            {
                s += c.Value();
            }
            return s;
        }

        public bool AllCatfishes()
        {
            foreach (Fisher f in fishers)
            {
                if (!f.CatchedCatfish(this))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
