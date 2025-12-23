using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class Card
    {
        public string cNum;
        private string pin;

        public Card(string n, string p)
        {
            cNum = n;
            pin = p;   
        }
        
        public void SetPIN(string p)
        {
            pin = p;
        }

        public bool CheckPIN(string p)
        {
            return pin == p;
        }
    }
}
