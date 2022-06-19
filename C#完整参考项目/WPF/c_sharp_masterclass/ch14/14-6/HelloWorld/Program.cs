using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread thread = new Thread(() => { PrintHello(); });
            thread.Start();

            //thread.Join();
            while(thread.IsAlive)
            {
                Console.WriteLine("子线程工作中");
                Thread.Sleep(100);
            }

            Console.WriteLine("退出主程序");
        }

        private static void PrintHello()
        {
            int i = 0;
            while (i++ < 10)
            {
                Thread.Sleep(new Random().Next(100, 1000));
                Console.WriteLine("Hello from PrintHello");
            }
        }
    }
}
