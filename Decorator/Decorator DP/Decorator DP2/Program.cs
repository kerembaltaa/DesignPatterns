using System;

namespace Decorator_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent component = new Component();

            Console.WriteLine("Basic Component --" + component.Operation());
            Console.WriteLine("Decorator A --" + new DecoratorA(component).Operation());
            Console.WriteLine("Decorator B --" + new DecoratorB(component).Operation());
            Console.WriteLine("Decorator B - A --" + new DecoratorB(new DecoratorA(component)).Operation());


            Console.ReadKey();
        }
    }
    interface IComponent
    {
        string Operation();
    }
    class Component : IComponent
    {
        public string Operation()
        {
            return "Normal operation. ";
        }
    }
    class DecoratorA : IComponent
    {
        IComponent component;

        public DecoratorA(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += " decorated with A";

            return s;
        }
    }

    class DecoratorB : IComponent
    {
        IComponent component;

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += " decorated with B";

            return s;
        }

    }

}
