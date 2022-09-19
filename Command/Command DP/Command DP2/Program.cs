using System;

namespace Command_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            // Execute Start Command
            ICommand command = invoker.GetCommand("Start");
            command.Execute();
            // Execute Stop Commad
            command = invoker.GetCommand("Stop");
            command.Execute();
            Console.WriteLine("Command Pattern demo");
            Console.Read();
        }
    }
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
    public class StartCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("I am executing StartCommand");
        }
        public string Name
        {
            get { return "Start"; }
        }
    }
    public class StopCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("I am executing StopCommand");
        }
        public string Name
        {
            get { return "Stop"; }
        }
    }
    public class Invoker
    {
        ICommand cmd = null;
        public ICommand GetCommand(string action)
        {
            switch (action)
            {
                case "Start":
                    cmd = new StartCommand();
                    break;
                case "Stop":
                    cmd = new StopCommand();
                    break;
                default:
                    break;
            }
            return cmd;
        }
    }

}
