using System;

namespace State_DP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.AddProgram(20);
            server.AddProgram(10);
            server.AddProgram(30);

            Console.ReadLine();
        }
    }

    /// State abstract class
    public abstract class ServerState
    {
        public abstract void HandleState(Server context);
    }

    /// Concrete State
    public class OverloadState : ServerState
    {
        public override void HandleState(Server context)
        {
            Console.WriteLine(@"Server CPULevel is: {0}. Server state 
                 is overload. Some programs is closing.", context.CPULevel);
            context.CloseProgram(5);
            if (context.CPULevel > 80)
                context.State = new OverloadState();
            else
                context.State = new OkState();
        }
    }

    /// Concrete State
    public class OkState : ServerState
    {
        public override void HandleState(Server context)
        {
            Console.WriteLine(@"Server CPULevel is: {0}. Server state 
                   is OK."
                   , context.CPULevel);
        }
    }

    /// Context class
    public class Server
    {
        public int CPULevel { get; set; }

        private ServerState _state;
        public ServerState State
        {
            get { return _state; }
            set
            {
                _state = value;
                // Burada durum değişimleri sonucu çalıştırılacak 
                // davranışların başlatılma noktasınıda 
                // merkezileştirmiş oluyoruz.
                _state.HandleState(this);
            }
        }

        public Server()
        {
            this.CPULevel = 50;
            ControlServerCPULevel();
        }

        public void ControlServerCPULevel()
        {
            if (this.CPULevel > 80)
                this.State = new OverloadState();
            else
                this.State = new OkState();
        }

        public void CloseProgram(int programUsageCPU)
        {
            this.CPULevel -= programUsageCPU;
        }

        public void AddProgram(int programUsageCPU)
        {
            this.CPULevel += programUsageCPU;
            ControlServerCPULevel();
        }
    }
}
