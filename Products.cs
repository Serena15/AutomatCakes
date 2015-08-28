using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatCakes
{
    class Products
    {
        private int[] CountOfProducts;//количество товара

        private string[] ProductName = new string[] { "Кексы", "Печенье", "Вафли" };

        private int[] CostOfProducts;// цена товара

        public Products()// конструктор класса Product
        {
            this.CountOfProducts = new int[] { 4, 3, 10 };

            this.CostOfProducts = new int[] { 50, 10, 30 };
        }

        public int getCount(int i)// узнать о наличии товара
        {
            return CountOfProducts[i];
        }
        
        public void setCount(int i)// уменьшить количество товара на 1
        {
            CountOfProducts[i]--;
        }              

        public int getCost(int i) //узнать цену товара
        {
            return CostOfProducts[i];
        }

    }
}
