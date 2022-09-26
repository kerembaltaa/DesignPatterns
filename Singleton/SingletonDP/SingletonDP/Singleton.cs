using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    class Singleton
    {
        private static Singleton _example = null;
        public string word;

        private Singleton()
        {

        }

        public static Singleton get_example
        {
            get
            {
                if (_example == null)
                {
                    _example = new Singleton();
                    Random random = new Random();
                    string CurrentWord = "";
                    for (int i = 1; i <= 10; i++)
                    {
                        int sayi1 = random.Next(65, 91);
                        CurrentWord = CurrentWord + ((char)sayi1);
                    }
                    _example.word = CurrentWord;
                }
                return _example;
            }
        }
    }
}
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
