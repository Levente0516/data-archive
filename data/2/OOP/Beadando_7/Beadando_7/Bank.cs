using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class Bank
    {
        private List<Account> account;

        public Bank() 
        {
            account = new List<Account>();
        }

        public void OpenAccount(string cNum, Customer c)
        {
            Account accounts = new Account(cNum);
            c.AddAccount(accounts);
            account.Add(accounts);
        }

        public void ProvidesCard(string cNum)
        {
            Account acc = account.Find(a => a.accNum == cNum);
            if (acc != null)
            {
                Card newCard = new Card(cNum, "1234");
                acc.cards.Add(newCard);
            }
        }

        public int GetBalance(string cNum)
        {
            (bool i, Account accountt) = FindAccount(cNum);
            if (i)
            {
                return accountt.GetBalance();
            }
            
            return -1;
        }

        public void Transaction(string cNum, int amount)
        {
            (bool i, Account account) = FindAccount(cNum);

            if(i)
            {
                account.Change(amount);
            }
        }

        public bool CheckAccount(string cNum)
        {
            return account.Exists(a => a.accNum == cNum);
        }

        public (bool, Account) FindAccount (string cNum)
        {
            foreach (var acc in account)
            {
                if (acc.accNum == cNum)
                {
                    return (true, acc);
                }
            }

            return (false, null);
        }
    }
}
