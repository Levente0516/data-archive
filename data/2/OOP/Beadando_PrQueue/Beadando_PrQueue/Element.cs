using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_PrQueue
{
    public class Element
    {
        public int pr;
        public string data;

        public Element() 
        {
            
        }
        public Element(Element element) 
        {
            pr = element.pr;
            data = element.data;
        }

        public Element(int pr, string data) 
        {
            this.pr = pr;
            this.data = data;
        }
    }
}
