using System;

namespace Strategy_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer srz = new Serializer(new XmlSerializer());

            srz.Serialize("Strategy");
            srz.Deserialize("Strategy");

            Console.WriteLine();

            srz = new Serializer(new BinarySerializer());

            srz.Serialize("");
            srz.Deserialize("");

            Console.WriteLine();

            srz = new Serializer(new JsonSerializer());

            srz.Serialize("New object");
            srz.Deserialize("New object");

        }
    }
    //Base Interface
    interface ISerializable
    {
        void Serialize(string str);
        void Deserialize(string str);
    }

    //Concrete tip 1
    class XmlSerializer : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("xml ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("xml serileştirme");
        }
    }

    //Concrete tip 2
    class BinarySerializer : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("binary ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("binary serileştirme");
        }
    }

    //Concrete tip 3(yeni eklenen)
    class JsonSerializer : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("json ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("json serileştirme");
        }
    }

    //Context tip
    class Serializer
    {
        ISerializable _serializer;

        public Serializer(ISerializable serializer)
        {
            _serializer = serializer;
        }

        public void Serialize(string str)
        {
            _serializer.Serialize(str);
        }

        public void Deserialize(string str)
        {
            _serializer.Deserialize(str);
        }
    }
}
