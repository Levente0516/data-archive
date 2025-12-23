using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class Account
    {
        public string accNum;
        private int balance;
        public List<Card> cards { get; set; }

        public Account(string n) 
        {
            accNum = n;
            balance = 0;
            cards = new List<Card>();
        }

        public int GetBalance()
        {
            return balance;
        }

        public void Change(int a)
        {
            balance += a;
        }
    }
}
