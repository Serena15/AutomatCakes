using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Automat : Products // класс Automat наследник класса Products
    {
        private int AutomatBalance; // баланс автомата

        public Automat()    
        {
            this.AutomatBalance = 0;
        } //конструктор автомата - создает экземпляр класса Automat

        public int getAutomatBalance()
        {
            return this.AutomatBalance;
        } //узнать баланс автомата

        public void setAutomatBalance(int sum, int sign)
        {
            if ((sign == -1) && (sum <= AutomatBalance))
                AutomatBalance -= sum;

            else if(sign == -1)
                AutomatBalance = 0;

            else
                AutomatBalance += sum;
        } //установить баланс автомата

        public int Sum(int len, char[] array)
        {
            int money = 0;

            bool flag = false;

            for (int i = 0; i < len - 1; i++)
            {

                if (array[i].Equals('2'))
                {
                    money += 2;
                }

                else if (array[i].Equals('5'))
                {
                    money += 5;
                }

                else if (array[i].Equals('1') && !(i >= len - 2))
                {

                    if (array[i + 1].Equals('0'))
                    {
                        money += 10;                        
                        i++;
                    }

                    else
                     money += 1; 
                }

                else if (array[i].Equals('1'))
                {
                    flag = true;                   
                }

                else
                {
                    Console.WriteLine("\n Ошибка ввода \n");

                    return 0;
                }

            }

            if (flag)
            {
                if (array[len - 1].Equals('0'))
                {
                    money += 10;
                }
                else money += 1;
            }

            else if (array[len - 1].Equals('1') || array[len - 1].Equals('2') || array[len - 1].Equals('5'))
            {
                string s = array[len - 1].ToString();

                money += Convert.ToInt32(s);
            }
            
            else
            {
                Console.WriteLine("\n Ошибка ввода\n");

                return 0;
            }

            return money;
        } //посчитать внесенную сумму

        public void Error() // метод вызова ошибки класса Automat
        {
            Console.WriteLine("\n Такого пункта меню не существует, повторите попытку снова \n");
        }

        public void Menu(Customer I, string name) // метод Меню автомата
        {
            short command = 0;

            string a;

            while (true)
            {
                Console.WriteLine("\n Приветствуем Вас, " + name + "!\n");
                Console.WriteLine(" Чтобы совершить покупку, внесите монеты номиналом 1, 2, 5, 10, \n");
                Console.WriteLine(" выберите товар или получите сдачу\n");

                Console.WriteLine(" Выберите действие: \n");

                Console.WriteLine(" 1. Внести сумму \n 2. Выбрать товар \n 3. Получить сдачу \n 4. Посмотреть баланс кошелька\n 5. Посмотреть доступные средства\n 6. Посмотреть наличие товара \n 7. Выйти \n");
                                
                a = Console.ReadLine();           
                               
                int l = a.Length;

                if (l != 1)
                {
                    Error();
                }
                else
                {
                    char[] mass = a.ToCharArray();

                    bool flag = false;

                    flag = char.IsNumber(mass[0]);

                    if (flag)
                    {
                        command = short.Parse(a);

                        if (command == 7) break;

                        switch (command)
                        {
                            case 1:
                                {
                                    Console.WriteLine("\n Внесите монеты номиналом 1, 2, 5, 10(разделяя их запятой\n или пробелом) и нажмите Enter: \n");

                                    a = Console.ReadLine();

                                    a = a.Replace(" ", "");

                                    a = a.Replace(",", "");

                                    int len = a.Length;

                                    int money;

                                    char[] array = a.ToCharArray();

                                    money = Sum(len, array);

                                    setAutomatBalance(I.PayInMoney(money),1);

                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("\n Выберите товар и нажмите соответствующую ему клавишу:\n");

                                    Console.WriteLine(" 1. Кексы по 50 р. \n 2. Печенье по 10 р. \n 3. Вафли по 30 р. \n 4. Выйти из меню выбора товара \n");

                                    Console.WriteLine(" Наличие товара:\n");

                                    Console.WriteLine(" Кексов {0}\n", getCount(0));

                                    Console.WriteLine(" Печенья {0}\n", getCount(1));

                                    Console.WriteLine(" Вафлей {0}\n", getCount(2));

                                    a = Console.ReadLine();

                                    int k = a.Length;

                                    if (k != 1)
                                    {
                                        Error();
                                    }
                                    else
                                    {
                                        char[] mass1 = a.ToCharArray();

                                        bool flag1 = false;

                                        flag1 = char.IsNumber(mass1[0]);

                                        if (flag1)
                                        {
                                            int command1 = short.Parse(a);

                                            if (command1 == 4) break;

                                            if (command1 < 1 || command1 > 4)
                                            {
                                                Error();
                                                break;
                                            }
                                            else
                                            {
                                                if (getCount(command1 - 1) == 0)
                                                {
                                                    Console.WriteLine("\n Извините,товар закончился\n");
                                                    break;
                                                }
                                                else
                                                {
                                                    bool flag2 = false;
                                                    flag2 = I.Select(command1, getAutomatBalance());                                                   
                                                    if (!flag2)
                                                    {
                                                        setCount(command1 - 1);
                                                        setAutomatBalance(getCost(command1 - 1), -1);
                                                    }
                                                }
                                            }

                                            }
                                        
                                        else
                                        {
                                            Error();
                                        }
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    I.GetChange(getAutomatBalance());
                                    setAutomatBalance(getAutomatBalance(), -1);
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("\n Ваш баланс : {0}\n", I.getBalance());
                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine("\n Ваша внесенная сумма : {0}\n", getAutomatBalance());
                                    break;
                                }
                            case 6:
                                {
                                    Console.WriteLine(" Кексов {0}\n", getCount(0));

                                    Console.WriteLine(" Печенья {0}\n", getCount(1));

                                    Console.WriteLine(" Вафлей {0}\n", getCount(2));

                                    break;
                                }
                            default:
                                {
                                    Error();
                                    break;
                                }
                        }

                    }
                    else
                    {
                        Error();
                    }
                }

            }
        }
    }
}
