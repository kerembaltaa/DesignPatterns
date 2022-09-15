using System;

namespace Decorator_DP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Model = "Astra", Brand = "Opel", Price = 35.1m, Description = "New car added." };
            car.PrintDetail();

            //nesnemize airbag özelliği ekleniyor
            AirbagDecorator carWithairbag = new AirbagDecorator(car);
            carWithairbag.PrintDetail();

            //nesnemize abs özelliği ekleniyor
            ABSDecorator carWithABS = new ABSDecorator(car);
            carWithABS.PrintDetail();

            Console.ReadLine();
        }
    }
    public interface ICarDecorator
    {
        void PrintDetail();
        void AddPrice(decimal addedPrice);
        void AddDescription(string addedDesc);
    }

    public class Car : ICarDecorator
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Car()
        {
            Price = 10.6m;
        }

        public void PrintDetail()
        {
            Console.WriteLine(Description);
        }

        public void AddPrice(decimal addedPrice)
        {
            Price += addedPrice;
        }

        public void AddDescription(string addedDesc)
        {
            Description = "Model: " + Model + " Brand: " + Brand + " Current Price: " + Price.ToString() + " " + addedDesc;
        }
    }

    public class CarDecoratorBase : ICarDecorator
    {
        internal ICarDecorator Car;
        public CarDecoratorBase(ICarDecorator car)
        {
            Car = car;
        }
        public virtual void PrintDetail()
        {
            Car.PrintDetail();
        }

        public virtual void AddPrice(decimal addedPrice)
        {
            Car.AddPrice(addedPrice);
        }

        public virtual void AddDescription(string addedDesc)
        {
            Car.AddDescription(addedDesc);
        }
    }

    public class ABSDecorator : CarDecoratorBase
    {
        public ABSDecorator(ICarDecorator car)
            : base(car)
        {
        }

        public override void PrintDetail()
        {
            base.Car.AddPrice(6.1m);
            base.Car.AddDescription("ABS added to current car.");
            base.Car.PrintDetail();
        }
    }

    public class AirbagDecorator : CarDecoratorBase
    {
        public AirbagDecorator(ICarDecorator car)
            : base(car)
        {
        }

        public override void PrintDetail()
        {
            base.Car.AddPrice(3.4m);
            base.Car.AddDescription("Airbag added to current car.");
            base.Car.PrintDetail();
        }
    }
}
