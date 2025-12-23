using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class ATM
    {
        public string site;
        private Center center;

        public ATM(string s, Center c) 
        {
            this.site = s;
            this.center = c;
        }

        public void Process(Customer c)
        {
            Card card = c.ProvidesCard();
            if (card.CheckPIN(c.ProvidesPIN()))
            {
                int a = c.RequestMoney();

                if (center.GetBalance(card.cNum) >= a)
                {
                    center.Transaction(card.cNum, -a);
                }
            }
        }
    }
}
