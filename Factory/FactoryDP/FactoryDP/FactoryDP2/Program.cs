using System;

namespace FactoryDP2
{
    class Program
    {
        static void Main(string[] args)
        {
            IShip _ship1 = Factory.getShip("ContainerShip", "MSC", 50, 1000);

            IShip _ship2 = Factory.getShip("TransportationShip", "IDO", 180, 10);

            Console.WriteLine("Properties of ContainerShip: ");
            if (_ship1 !=null)
                Console.WriteLine(_ship1.ToString());


            Console.WriteLine("Properties of TransportationShip: ");
            if (_ship2 != null)
                Console.WriteLine(_ship2.ToString());
        }
    }
}
