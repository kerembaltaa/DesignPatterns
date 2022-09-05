using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Creater create = new Creater(new SqlDatabase());
            Console.WriteLine("**********");
            create = new Creater(new MySqlDatabase());
            Console.Read();
        }
    }
    abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool DisConnect();
        public abstract string State { get; }
    }

    abstract class Command
    {
        public abstract void Execute(string query);
    }

    class SqlConnection : Connection
    {
        public override string State => "Open";
        public override bool Connect()
        {
            Console.WriteLine("SqlConnection bağlantısı kuruluyor.");
            return true;
        }
        public override bool DisConnect()
        {
            Console.WriteLine("SqlConnection bağlantısı kesiliyor.");
            return false;
        }
    }

    class SqlCommand : Command
    {
        public override void Execute(string query) => Console.WriteLine("SqlCommand sorgusu çalıştırıldı.");
    }

    class MySqlConnection : Connection
    {
        public override string State => "Open";
        public override bool Connect()
        {
            Console.WriteLine("MySqlConnection bağlantısı kuruluyor.");
            return true;
        }
        public override bool DisConnect()
        {
            Console.WriteLine("MySqlConnection bağlantısı kesiliyor.");
            return false;
        }
    }

    class MySqlCommand : Command
    {
        public override void Execute(string query) => Console.WriteLine("MySqlCommand sorgusu çalıştırıldı.");
    }

    abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    class SqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new SqlCommand();
        public override Connection CreateConnection() => new SqlConnection();
    }

    class MySqlDatabase : DatabaseFactory
    {
        public override Command CreateCommand() => new MySqlCommand();
        public override Connection CreateConnection() => new MySqlConnection();
    }

    class Creater
    {
        DatabaseFactory _databaseFactory;
        Connection _connection;
        Command _command;
        public Creater(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = _databaseFactory.CreateCommand();

            Start();
        }

        void Start()
        {
            if (_connection.State == "Open")
            {
                _connection.Connect();
                _command.Execute("Select * from...");
                _connection.DisConnect();
            }
        }
    }


}
