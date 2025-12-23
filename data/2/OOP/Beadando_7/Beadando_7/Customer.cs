using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class Customer
    {
        private string pin;
        private int withdraw;
        public List<Account> accounts;
        public Customer(string p, int w) 
        {
            this.pin = p;
            this.withdraw = w;
            accounts = new List<Account>();
        }

        public void Withdrawal(ATM atm)
        {
            atm.Process(this);
        }

        public Card ProvidesCard()
        {
            return accounts[0].cards[0];
        }

        public string ProvidesPIN()
        {
            return pin;
        }

        public int RequestMoney()
        {
            return withdraw;
        }

        public void AddAccount(Account a)
        {
            accounts.Add(a);
        }
    }
}
