using System;
using System.IO;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static object lockedObj = new object();

        static void Main(string[] args)
        {

            for(int i=0; i<10; i++)
            {
                var t = new Thread(AddText);
                t.Start();
            }

            Console.WriteLine("退出主程序");
        }

        static void AddText()
        {
            lock (lockedObj)
            {
                File.AppendAllText(@"D:\test.txt", $"开始 {Thread.CurrentThread.ManagedThreadId} ");
                Thread.Sleep(100);
                File.AppendAllText(@"D:\test.txt", $"结束 {Thread.CurrentThread.ManagedThreadId} ");
            }
        }
    }
}
