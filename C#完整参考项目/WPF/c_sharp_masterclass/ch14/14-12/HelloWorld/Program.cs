using System;
using System.Diagnostics;
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
            // 异步不是多线程
            // 异步 并行
            // 多线程 并发
            // Task vs Thread
            //TaskTest();
            //ThreadTest();

            //Thread t = new Thread(() =>
            //{
                DoSomething();
            //});
            //t.Start();


            Console.WriteLine("主程序结束");
        }

        static void DoSomething()
        {
            Console.WriteLine("异步 task 开始");
            Task.Delay(60000).Wait();
            Console.WriteLine("异步 task 结束");
        }

        static void TaskTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            for(int i = 0; i < 100; i++)
            {
                Task.Factory.StartNew(() => { });
            }

            sw.Stop();
            Console.WriteLine($"Task {sw.ElapsedMilliseconds}");
        }

        static void ThreadTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 100; i++)
            {
                new Thread(() => { }).Start();
            }

            sw.Stop();
            Console.WriteLine($"Thread {sw.ElapsedMilliseconds}");
        }
    }
}
