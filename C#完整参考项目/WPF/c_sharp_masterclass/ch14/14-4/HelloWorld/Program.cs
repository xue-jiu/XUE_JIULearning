using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(PrintHello);
            //thread.IsBackground = true;
            //thread.Start();

            for(int i=0; i<100; i++)
            {
                //var t = new Thread(()=> {
                //    Console.WriteLine($"循环次数 {i} 线程id {Thread.CurrentThread.ManagedThreadId}");
                //});
                //t.Start();
                ThreadPool.QueueUserWorkItem((o) => {
                    Console.WriteLine($"线程id {Thread.CurrentThread.ManagedThreadId}");
                });
            }

            Thread.Sleep(5000);
            Console.WriteLine("退出主程序");
        }

        private static void PrintHello(object obj)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello from PrintHello");
            }
        }
    }
}
