using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Parallel.Invoke(
    //            () => PrintTeacherDetails(),
    //            () => PrintStudentdetails()
    //            );
    //        Console.ReadLine();
    //    }
    //    private static void PrintTeacherDetails()
    //    {
    //        Singleton fromTeacher = Singleton.GetInstance;
    //        fromTeacher.PrintDetails("From Teacher");
    //    }
    //    private static void PrintStudentdetails()
    //    {
    //        Singleton fromStudent = Singleton.GetInstance;
    //        fromStudent.PrintDetails("From Student");
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {

            Singleton firstS = Singleton.get_example;
            Singleton secondS = Singleton.get_example;



        }
    }
}