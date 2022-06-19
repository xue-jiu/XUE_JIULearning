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

        static async void Calculate()
        {
            // Task -> 异步
            // Thread -> 线程
            var result1 = await Calculate1Async();
            var result2 = await Calculate2Async(result1);
            var result = Calculate3Async(result1, result2);
            Console.WriteLine(result);
        }

        static async Task<int> Calculate1Async()
        {
            var result = 3;
            Console.WriteLine($"Calculate1: {result}");
            await Task.Delay(3000);
            return result;
        }

        static async Task<int> Calculate2Async(int a)
        {
            var result = a*2;
            Console.WriteLine($"Calculate2: {result}");
            await Task.Delay(2000);
            return result;
        }

        static int Calculate3Async(int a, int b)
        {
            var result = a + b;
            Console.WriteLine($"Calculate3: {result}");
            return result;
        }
    }
}
