using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Automat Cakes = new Automat();

            Console.WriteLine("Введите имя покупателя:\n");

            Customer I = new Customer(Console.ReadLine());

            Cakes.Menu(I);
        }
    }
}
