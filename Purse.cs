using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Purse
    {

        private int balance;

        public Purse()
        {
            this.balance = 150;
        }

        public int getBalance()
        {
            return balance;
        }

        public void setBalance(int money, int sign)
        {
            if (sign == -1)
                balance -= money;
            else
                balance += money;
        }

    }
}
