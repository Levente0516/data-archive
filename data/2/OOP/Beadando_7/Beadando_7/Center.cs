using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_7
{
    public class Center
    {
        List<Bank> banks;
        public Center(List<Bank> b) 
        {
            banks = new List<Bank>(b);
        }

        public int GetBalance(string cNum)
        { 
            (bool i, Bank bank) = FindBank(cNum);

            if (i)
            {
                return bank.GetBalance(cNum);
            }
            else
            {
                return -1;
            }
        }

        public void Transaction(string cNum, int amount)
        {
            (bool i, Bank bank) = FindBank(cNum);

            if (i)
            {
                bank.Transaction(cNum, amount);
            }
        }

        private (bool,Bank) FindBank(string cNum)
        {
            foreach (var bank in banks)
            {
                if (bank.CheckAccount(cNum))
                {
                    return (true, bank);

                }
            }

            return (false, null);
        }
    }
}
