using System;

namespace Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                using var db = new DatabaseHelper();
                var date = db.GetData();
                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()} ; {date}]");
            }

            Console.WriteLine("程序结束");
        }
    }
}
