using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_PrQueue
{
    public class PrQueue
    {
        private List<Element> seq = new();

        public class SeqEmpty : Exception
        {

        }
        
        public void SetEmpty()
        {
            seq = new();
        }

        public bool isEmpty()
        {
            if (seq.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void Add(Element e)
        {
            seq.Add(new Element(e));
        }

        public Element GetMax()
        {
            if (isEmpty())
            {
                throw new SeqEmpty();
            }
            (int max, int ind) = MaxSelect();
            return seq[ind];
        }

        public Element RemMax()
        {
            if (isEmpty())
            {
                throw new SeqEmpty();
            }
            (int max, int ind) = MaxSelect();

            Element e = seq[ind];

            seq.RemoveAt(ind);

            return e;
        }

        public (int, int) MaxSelect()
        {
            if (isEmpty())
            {
                throw new SeqEmpty();
            }

            int max = seq[0].pr;
            int ind = 0;
            for (int i = 0; i < seq.Count; i++)
            {
                if (max < seq[i].pr)
                {
                    max = seq[i].pr;
                    ind = i;
                }
            }

            return (max, ind);
        }
    }
}
