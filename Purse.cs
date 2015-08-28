using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Purse // кошелек покупателя
    {

        private int balance; // сумма,которая содержиться в кошельке

        public Purse() //конструктор класса Purse
        {
            this.balance = 150;
        }

        public int getBalance() //узнать баланс кошелька
        {
            return balance;
        }

        public void setBalance(int money, int sign) // изменить баланс кошелька
        {
            if (sign == -1)
                balance -= money;
            else
                balance += money;
        }

    }
}
