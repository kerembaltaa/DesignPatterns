using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class ShipFactory : MainFactory
    {
        public override IVehicle GetVehicle(string VehicleType)
        {

            if (VehicleType.Equals("Container Ship"))
            {
                return new ContainerShip();
            }
            else if (VehicleType.Equals("Transportation Ship"))
            {
                return new TransportationShip();
            }
            else
                return null;
        }
    }
}
