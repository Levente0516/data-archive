using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public class Item
    {
        public int key;
        public string data;

        public Item(Item item)
        {
            key = item.key;
            data = item.data;
        }

        public Item(int key, string data)
        {
            this.key = key;
            this.data = data;
        }

        public override string ToString()
        {
            return "(" + key.ToString() + ":" + data + ")";
        }
    }
}
