using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP2
{
    class Product1 : Interface1
    {
        private string name;
        private string brand;
        private int price;
        private int amount;

        public Product1(string name, string brand, int price, int amount)
        {
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.amount = amount;
        }

        public string getName()
        {
            return name;
        }

        public string getBrand()
        {
            return brand;
        }


        public int getPrice()
        {
            return price;
        }

        public int getAmount()
        {
            return amount;
        }


        public override string ToString()
        {
            return "Product1:" +
                    "Name=" + name +
                    ", Brand=" + brand +
                    ", Price=" + price +
                    ", Amount=" + amount
                    ;
        }

    }
}
