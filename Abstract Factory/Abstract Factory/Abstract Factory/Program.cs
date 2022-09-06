using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ShipInterface _ship1 = Factory.getShip("ContainerShip", "MSC", 50, 1000);

            ShipInterface _ship2 = Factory.getShip("TransportationShip", "IDO", 180, 10);

            Console.WriteLine("Properties of ContainerShip: ");
            if (_ship1 != null)
                Console.WriteLine(_ship1.ToString());


            Console.WriteLine("Properties of TransportationShip: ");
            if (_ship2 != null)
                Console.WriteLine(_ship2.ToString());
        }
    }

}
