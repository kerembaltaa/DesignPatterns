using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    //public sealed class Singleton
    //{
    //    private static int counter = 0;
    //    private static readonly object Instancelock = new object();
    //    private Singleton()
    //    {
    //        counter++;
    //        Console.WriteLine("Counter Value " + counter.ToString());
    //    }
    //    private static Singleton instance = null;

    //    public static Singleton GetInstance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                lock (Instancelock)
    //                {
    //                    if (instance == null)
    //                    {
    //                        instance = new Singleton();
    //                    }
    //                }
    //            }
    //            return instance;
    //        }
    //    }
    //    public void PrintDetails(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}
    class Singleton
    {
        private static Singleton _example = null;

        private Singleton()
        {
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                int sayi1 = random.Next(65, 91);
                Console.Write((char)sayi1);
            }
            Console.WriteLine();
        }

        public static Singleton get_example
        {
            get
            {
                if (_example == null)
                {
                    _example = new Singleton();
                }
                return _example;
            }
        }
    }
}
