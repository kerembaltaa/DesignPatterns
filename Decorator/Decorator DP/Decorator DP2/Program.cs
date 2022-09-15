using System;

namespace Decorator_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent component = new Component();

            Console.WriteLine("Basic Component " + component.Operation());
            Console.WriteLine("Decorator A " + new DecoratorA(component).Operation());
            Console.WriteLine("Decorator B " + new DecoratorB(component).Operation());
            Console.WriteLine("Decorator B - A" + new DecoratorB(new DecoratorA(component)).Operation());

            DecoratorB b = new DecoratorB(new Component());

            Console.WriteLine("b.addedState " + b.AddedBehavior());

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
            return "I am walking ";
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
            s += " and listening to Classin FM";

            return s;
        }
    }

    class DecoratorB : IComponent
    {
        IComponent component;
        public string addedState = "past the coffe shop ";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += " to School";

            return s;
        }

        public string AddedBehavior()
        {
            return " and I bought a cappicuno";
        }
    }

}
