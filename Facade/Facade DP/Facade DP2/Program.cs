using System;

namespace Facade_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.Operation1();
            facade.Operation2();

            Console.ReadKey();
        }
    }
    class SubsystemA
    {
        public string OperationA1()
        {
            return "Subsystem A, Method A1\n";
        }
        public string OperationA2()
        {
            return "Subsystem A, Method A2\n";
        }
    }
    class SubsystemB
    {
        public string OperationB1()
        {
            return "Subsystem B, Method B1\n";
        }

        public string OperationB2()
        {
            return "Subsystem B, Method B2\n";
        }
    }
    class SubsystemC
    {
        public string OperationC1()
        {
            return "Subsystem C, Method C1\n";
        }

        public string OperationC2()
        {
            return "Subsystem C, Method C2\n";
        }
    }

    public class Facade
    {
        SubsystemA a = new SubsystemA();
        SubsystemB b = new SubsystemB();
        SubsystemC c = new SubsystemC();
        public void Operation1()
        {
            Console.WriteLine("Operation 1\n" +
            a.OperationA1() +
            a.OperationA2() +
            b.OperationB1());
        }
        public void Operation2()
        {
            Console.WriteLine("Operation 2\n" +
            b.OperationB2() +
            c.OperationC1() +
            c.OperationC2());
        }
    }
}
