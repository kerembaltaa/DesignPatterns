using System;

namespace Visitor_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            IPad iPad = new IPad("Ipad mini", "Apple");
            GalaxyTab galaxyTab = new GalaxyTab("Galaxy Tab", "Samsung");

            iPad.Accept(new WifiVisitor());
            galaxyTab.Accept(new WifiVisitor());

            iPad.Accept(new ThreeGVisitor());
            galaxyTab.Accept(new ThreeGVisitor());

            //bunun gibi baska visitor sınıfları yazarak sınıfımızı değiştirmeden
            //yeni metotlar çalıştırabilir hale getirebiliriz. 

            Console.ReadLine();
        }
    }
    /// <summary>
    /// The 'Tablet' abstract class
    /// </summary>
    public abstract class Tablet
    {
        public string Model { get; set; }
        public string Brand { get; set; }

        public Tablet(string model, string brand)
        {
            Model = model;
            Brand = brand;
        }

        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    public class IPad : Tablet
    {
        public IPad(string model, string brand)
            : base(model, brand)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    public class GalaxyTab : Tablet
    {
        public GalaxyTab(string model, string brand)
            : base(model, brand)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    public interface IVisitor
    {
        void Visit(Tablet tablet);
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    public class WifiVisitor : IVisitor
    {
        public void Visit(Tablet tablet)
        {
            if (tablet is IPad)
                Console.WriteLine("Ipad wifi has open.");
            else if (tablet is GalaxyTab)
                Console.WriteLine("GalaxyTab does not have wifi option.");
            else
                Console.WriteLine("This object is not a tablet.");
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    public class ThreeGVisitor : IVisitor
    {
        public void Visit(Tablet tablet)
        {
            if (tablet is IPad)
                Console.WriteLine("Ipad wifi does not have 3G option.");
            else if (tablet is GalaxyTab)
                Console.WriteLine("GalaxyTab 3G has open.");
            else
                Console.WriteLine("This object is not a tablet.");
        }
    }
}
