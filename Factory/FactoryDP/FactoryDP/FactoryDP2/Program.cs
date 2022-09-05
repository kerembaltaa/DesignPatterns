using System;

namespace FactoryDP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface1 ürün1 = Factory.getProduct("Product1", "Brand1", 500, 3);

            Interface1 ürün2 = Factory.getProduct("Product2", "Brand2", 1500, 2);

            Console.WriteLine("Properties of Product1: ");
            Console.WriteLine(ürün1.ToString());

            Console.WriteLine("Properties of Product2: ");
            Console.WriteLine(ürün2.ToString());
        }
    }
}
