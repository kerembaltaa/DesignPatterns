using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP2
{
    class Factory
    {
        public static Interface1 getProduct(string name, string brand, int price, int amount)
        {

            Interface1 ürün;
            if ("Product1"==(name))
            {
                ürün = new Product1(name, brand, price, amount);
            }
            else if ("Product2"==(name))
            {
                ürün = new Product1(name, brand, price, amount);
            }
            else
            {
                ürün = null;
                Console.WriteLine("Geçerli bir ürün değildir!");
            }

            return ürün;
        }
    }
}
