using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class AirCraftFactory : MainFactory
    {
        public override IVehicle GetVehicle(string VehicleType)
        {
            if (VehicleType.Equals("Plane"))
            {
                return new Plane();
            }
            else if (VehicleType.Equals("Helicopter"))
            {
                return new Helicopter();
            }
            else
                return null;
        }
    }
}
