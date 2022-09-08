using System;

namespace Abstract_Factory
{
    
    class MainApp
    {
       
        public static void Main()
        {

            IVehicle _vehicle = null;
            MainFactory _mainFactory = null;
            string _properties = null;
            
            _mainFactory = MainFactory.CreateVehicleFactory("Air Craft Factory");
            Console.WriteLine("Air Craft Factory type : " + _mainFactory.GetType().Name);
            Console.WriteLine();

            _vehicle = _mainFactory.GetVehicle("Plane");
            Console.WriteLine("Vehicle Type : " + _vehicle.GetType().Name);
            _properties = _vehicle.info();
            Console.WriteLine(_vehicle.GetType().Name + " Infos : " + _properties);
            Console.WriteLine();

            _vehicle = _mainFactory.GetVehicle("Helicopter");
            Console.WriteLine("Vehicle Type : " + _vehicle.GetType().Name);
            _properties = _vehicle.info();
            Console.WriteLine(_vehicle.GetType().Name + " Infos : " + _properties);
            Console.WriteLine();
            Console.WriteLine("--------------------------");

            _mainFactory = MainFactory.CreateVehicleFactory("Ship Factory");
            Console.WriteLine("Ship Factory type : " + _mainFactory.GetType().Name);
            Console.WriteLine();

            _vehicle = _mainFactory.GetVehicle("Transportation Ship");
            Console.WriteLine("Vehicle Type : " + _vehicle.GetType().Name);
            _properties = _vehicle.info();
            Console.WriteLine(_vehicle.GetType().Name + " Infos : " + _properties);
            Console.WriteLine();

            _vehicle = _mainFactory.GetVehicle("Container Ship");
            Console.WriteLine("Vehicle Type : " + _vehicle.GetType().Name);
            _properties = _vehicle.info();
            Console.WriteLine(_vehicle.GetType().Name + " Infos : " + _properties);
            Console.Read();
        }
    }
    //public interface Vehicle
    //{
    //    string info();
    //}

    //public class ContainerShip : Vehicle
    //{
    //    public string info()
    //    {
    //        return "MSC";
    //    }
    //}
    //public class TransportationShip : Vehicle
    //{
    //    public string info()
    //    {
    //        return "IDO";
    //    }
    //}
   
    //public class Helicopter : Vehicle
    //{
    //    public string info()
    //    {
    //        return "Private Helicopters";
    //    }
    //}

    //public class Plane : Vehicle
    //{
    //    public string info()
    //    {
    //        return "Turkish Airlines";
    //    }
    //}

    //public abstract class MainFactory
    //{
    //    public abstract Vehicle GetVehicle(string VehicleType);
    //    public static MainFactory CreateVehicleFactory(string FactoryType)
    //    {
    //        if (FactoryType.Equals("Air Craft Factory"))
    //            return new AirCraftFactory();
    //        else
    //            return new ShipFactory();
    //    }
    //}

    //public class ShipFactory : MainFactory
    //{
    //    public override Vehicle GetVehicle(string VehicleType)
    //    {
           
    //        if (VehicleType.Equals("Container Ship"))
    //        {
    //            return new ContainerShip();
    //        }
    //        else if (VehicleType.Equals("Transportation Ship"))
    //        {
    //            return new TransportationShip();
    //        }
    //        else
    //            return null;
    //    }
    //}
    //public class AirCraftFactory : MainFactory
    //{
    //    public override Vehicle GetVehicle(string VehicleType)
    //    {
    //        if (VehicleType.Equals("Plane"))
    //        {
    //            return new Plane();
    //        }
    //        else if (VehicleType.Equals("Helicopter"))
    //        {
    //            return new Helicopter();
    //        }
    //        else
    //            return null;
    //    }
    //}
}
