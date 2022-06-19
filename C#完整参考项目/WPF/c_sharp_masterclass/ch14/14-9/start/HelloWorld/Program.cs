using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate();
            Console.Read();
        }

        static void Calculate()
        {
            Calculate1();
            Calculate2();
            Calculate3();
        }

        static int Calculate1()
        {
            var result = 3;
            Console.WriteLine($"Calculate1: {result}");
            Task.Delay(2000);
            return result;
        }

        static int Calculate2()
        {
            var result = 4;
            Console.WriteLine($"Calculate2: {result}");
            Task.Delay(3000);
            return result;
        }

        static int Calculate3()
        {
            var result = 5;
            Console.WriteLine($"Calculate3: {result}");
            Task.Delay(1000);
            return result;
        }
    }
}
