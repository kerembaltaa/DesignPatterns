using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public abstract class MainFactory
    {
        public abstract IVehicle GetVehicle(string VehicleType);
        public static MainFactory CreateVehicleFactory(string FactoryType)
        {
            if (FactoryType.Equals("Air Craft Factory"))
                return new AirCraftFactory();
            else
                return new ShipFactory();
        }
    }
}
