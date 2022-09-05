using System;

namespace FactoryDP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface1 _ship1 = Factory.getShip("ContainerShip", "MSC", 50, 1000);

            Interface1 _ship2 = Factory.getShip("TransportationShip", "IDO", 180, 10);

            Console.WriteLine("Properties of ContainerShip: ");
            Console.WriteLine(_ship1.ToString());

            Console.WriteLine("Properties of TransportationShip: ");
            Console.WriteLine(_ship2.ToString());
        }
    }
}
