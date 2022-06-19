using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Thread thread = new Thread(() => { PrintHello(tokenSource.Token); });
            thread.Start();

            // 下载文件
            Thread.Sleep(5000);

            // 关闭子线程
            tokenSource.CancelAfter(3000);

            Console.WriteLine("退出主程序");
        }

        private static void PrintHello(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello from PrintHello");
            }
        }
    }
}
