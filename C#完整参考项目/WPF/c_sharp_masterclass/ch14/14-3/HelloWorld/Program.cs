using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(() =>
            //{
            //    Print1();
            //});
            //thread.Start();
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write(0);
                Thread.Sleep(1000);
            }

            Console.Read();
        }

        static void Print1()
        {
            for(int i = 0; i < 1000; i++)
            {
                Console.Write(1);
            }
        }
    }
}
