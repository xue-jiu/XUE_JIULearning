using System;
using System.Diagnostics;

namespace Helloworld
{
    public class SuibianClass
    {
        public SuibianClass()
        {
            Console.WriteLine("SuibianClass 创建");
        }

        ~SuibianClass()
        {
            Console.WriteLine("SuibianClass 销毁");
        }
    }

    public class SecondClass : SuibianClass
    {
        public SecondClass()
        {
            Console.WriteLine("SecondClass 创建");
        }

        ~SecondClass()
        {
            Console.WriteLine("SecondClass 销毁");
        }
    }

    public class ThirdClass : SecondClass
    {
        public ThirdClass()
        {
            Console.WriteLine("ThirdClass 创建");
        }

        ~ThirdClass()
        {
            Console.WriteLine("ThirdClass 销毁");
        }
    }


    class Program
    {
        static void DoSomething()
        {
            new ThirdClass();
        }

        static void Main(string[] args)
        {
            DoSomething();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("程序结束");
        }
    }
}
