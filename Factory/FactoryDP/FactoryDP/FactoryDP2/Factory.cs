using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDP2
{
    class Factory
    {
        public static IShip getShip(string name, string company, int velocity, int max_weight)
        {

            IShip _ship;
            if ("ContainerShip"==(name))
            {
                _ship = new ContainerShip(name, company, velocity, max_weight);
                
            }
            else if ("TransportationShip"==(name))
            {
                _ship = new TransportationShip(name, company, velocity, max_weight);
            }
            else
            {
                _ship = null;
                Console.WriteLine("Not found!");
            }

            return _ship;
        }
    }
}
