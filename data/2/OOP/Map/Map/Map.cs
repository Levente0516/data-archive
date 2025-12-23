using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Map
    {
        public class NonExistingKeyException : Exception { }
        public class ExistingKeyException : Exception { }

        private List<Item> seq = new();
        
        public void SetEmpty()
        {
            seq = new();
        }

        public int Count()
        {
            return seq.Count;
        }

        private bool LogSearch(int key, out int ind)
        {
            ind = 0;
            bool l = false;
            int ll = 0;
            int ul = seq.Count - 1;
            while (ll <= ul)
            {
                ind = (ll + ul) / 2;
                if (seq[ind].key == key)
                {
                    l = true;
                    break;
                }
                else if (seq[ind].key > key)
                {
                    ul = ind - 1;
                }
                else if (seq[ind].key < key)
                {
                    ll = ind + 1;
                }
                if (!l)
                {
                    ind = ll;
                }
            }
            return l;
        }

        public void Insert(Item item) 
        {
            bool l = LogSearch(item.key, out int ind);
            if (!l)
            {
                seq.Insert(ind, new Item(item));
            }
            else
            {
                throw new ExistingKeyException();
            }
        }

        public void Remove(int key)
        {
            bool l = LogSearch(key, out int ind);
            if (l)
            {
                seq.RemoveAt(ind);
            }
            else
            {
                throw new NonExistingKeyException();
            }
        }

        public bool In(int key)
        {
            return LogSearch(key, out int ind);
        }

        public string Select(int key)
        {
            bool l = LogSearch(key, out int ind);
            if (l)
            {
                return seq[ind].data;
            }
            else
            {
                throw new NonExistingKeyException();
            }
        }

        public override string ToString()
        {
            string output = "[";
            foreach(Item item in seq)
            {
                output += item.ToString();
            }
            output += "]";
            return output;
        }

        public string this[int key]
        {
            get
            {
                return Select(key);
            }
        }
    }
}
