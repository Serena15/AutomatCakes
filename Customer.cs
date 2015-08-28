using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Customer : Purse // класс покупателя Customer - наследник класса Purse
    {
        private string Name; // имя покупателя

        public Customer(string name)// конструктор класса Customer
        {
            this.Name = name;
        }

        public string getName()// получить имя покупателя
        {
            return Name;
        }                     

        public int PayInMoney(int money)// метод класса Customer - внести сумму в автомат
        {

            if (money > this.getBalance())
            {
                Console.WriteLine("\n Недостаточно средств на Вашем счету!\n");
                return 0;
            }

            else
            {
                this.setBalance(money,-1);                
                Console.WriteLine("\n Вы внесли {0} рублей\n", money);
                return money;
            }
               
        }

        public bool Select(int choise, int money) // метод класса Customer - выбрать товар
        {

            if (choise == 1)
            {
                if (money < 50)
                {
                    Console.WriteLine("\n Недостаточно средств для покупки выбранного товара!\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("\n Получите товар : кексы \n");
                    return false;
                }
            }

            else if (choise == 2)
            {
                if (money < 10)
                {
                    Console.WriteLine("\n Недостаточно средств для покупки выбранного товара!\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("\n Получите товар : печенье \n");
                    return false;
                }
            }

            else if (choise == 3)
            {
                if (money < 30)
                {
                    Console.WriteLine("\n Недостаточно средств для покупки выбранного товара!\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("\n Получите товар : вафли \n");
                    return false;
                }
            }
            else return true;

        }

        public void GetChange(int AutomatBalance)// метод класса Customer - получить сдачу
        {

            if (AutomatBalance == 0)
            {
                Console.WriteLine("\n Нет денег на сдачу!\n");
                return;
            }

            else
            {
                this.setBalance(AutomatBalance, 1);
                MinCountOfCoin(AutomatBalance);
                Console.WriteLine("\n Всего : {0} р. \n", AutomatBalance);
                return;
            }
        }

        public void MinCountOfCoin(int sum) //минимальное количество монет на сдачу автоматом
        {
            int[] count = new int[] { 0, 0, 0, 0};

            while (sum > 0)
            {
                if (sum >= 10)
                {
                    sum -= 10;
                    count[3]++;
                }
                else if (sum >= 5)
                {
                    sum -= 5;
                    count[2]++;
                }
                else if (sum >= 2)
                {
                    sum -= 2;
                    count[1]++;
                }
                else
                {
                    sum -= 1;
                    count[0]++;
                }
            }

            Console.WriteLine("\n Возьмите Вашу сдачу: \n");

            for(int i = 1; i <= count[3]; i++)
                Console.WriteLine(" 10 ");

            for (int i = 1; i <= count[2]; i++)
                Console.WriteLine(" 5 ");

            for (int i = 1; i <= count[1]; i++)
                Console.WriteLine(" 2 ");

            for (int i = 1; i <= count[0]; i++)
                Console.WriteLine(" 1 ");
        }

    }
}
