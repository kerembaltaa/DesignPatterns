using System;
using System.Collections.Generic;

namespace Visitor_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IStore> store = new List<IStore>();
            IStore car1 = new Car() { CarName = "A1", Price = 200M, CarType = "Mercedes" };
            IStore car2 = new Car() { CarName = "A2", Price = 100M, CarType = "Normal" };

            IStore bike1 = new Bike() { BikeName = "B1", Price = 50M, BikeType = "Bullet" };
            IStore bike2 = new Bike() { BikeName = "B2", Price = 30M, BikeType = "Normal" };


            PriceVisitor priceVisitor = new PriceVisitor();
            car1.Visit(priceVisitor);
            car2.Visit(priceVisitor);

            bike1.Visit(priceVisitor);
            bike2.Visit(priceVisitor);


            WeightVisitor weightVisitor = new WeightVisitor();
            car1.Visit(weightVisitor);
            car2.Visit(weightVisitor);

            bike1.Visit(weightVisitor);
            bike2.Visit(weightVisitor);

            Console.ReadLine();
        }
    }
    public interface IStore
    {
        void Visit(IVisitor visitor);
    }
    public class Car : IStore
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string CarType { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
    public class Bike : IStore
    {
        public string BikeName { get; set; }
        public decimal Price { get; set; }
        public string BikeType { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
    public interface IVisitor
    {
        void Accept(Car car);
        void Accept(Bike bike);
    }
    public class PriceVisitor : IVisitor
    {
        private const int CAR_DISCOUNT = 5;
        private const int BIKE_DISCOUNT = 2;

        public void Accept(Car car)
        {
            decimal carPriceAfterDicount = car.Price - ((car.Price / 100) * CAR_DISCOUNT);
            Console.WriteLine("Car {0} price: {1}", car.CarName, carPriceAfterDicount);
        }

        public void Accept(Bike bike)
        {
            decimal bikePriceAfterDicount = bike.Price - ((bike.Price / 100) * BIKE_DISCOUNT);
            Console.WriteLine("Bike {0} price: {1}", bike.BikeName, bikePriceAfterDicount);
        }
    }
    public class WeightVisitor : IVisitor
    {
        public void Accept(Car car)
        {
            switch (car.CarType)
            {
                case "Mercedes":
                    Console.WriteLine("Car {0} weight: {1} KG", car.CarName, 1750);
                    break;
                case "Normal":
                    Console.WriteLine("Car {0} weight: {1} KG", car.CarName, 750);
                    break;
            }
        }

        public void Accept(Bike bike)
        {
            switch (bike.BikeType)
            {
                case "Bullet":
                    Console.WriteLine("Bike {0} weight: {1} KG", bike.BikeName, 300);
                    break;
                case "Normal":
                    Console.WriteLine("Bike {0} weight: {1} KG", bike.BikeName, 100);
                    break;
            }
        }
    }
}
