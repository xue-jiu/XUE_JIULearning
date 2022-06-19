using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Tuesday",
                "Monday",
                "Wendesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            foreach(var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            // 零索引 0-indexed
            Console.WriteLine(daysOfWeek[0]);
            Console.WriteLine(daysOfWeek[1]);
            Console.WriteLine(daysOfWeek[6]);

            // 安全
            //Console.WriteLine(daysOfWeek[7]);

            // 固定长度
            string[] daysOfWeek2 = new string[7];
            daysOfWeek2[0] = "Monday";
            daysOfWeek2[1] = "Tuesday";
            daysOfWeek2[2] = "Wendesday";
            daysOfWeek2[3] = "Thursday";
            daysOfWeek2[4] = "Friday";
            daysOfWeek2[5] = "Saturday";
            daysOfWeek2[6] = "Sunday";

            // 12-4 List 列表
            IList<string> daysOfWeek3 = new List<string>();
            daysOfWeek3.Add("Monday");
            daysOfWeek3.Add("Tuesday");
            daysOfWeek3.Add("Wendesday");
            daysOfWeek3.Add("Thursday");
            daysOfWeek3.Add("Friday");
            daysOfWeek3.Add("Saturday");
            daysOfWeek3.Add("Sunday");
            daysOfWeek3.Add("Sunday");
            daysOfWeek3.Add("Sunday");
            daysOfWeek3.Add("Sunday");
            daysOfWeek3.Add("Sunday");
            daysOfWeek3.Add("Sunday");

            // ArrayList
            var array = new ArrayList();
            array.Add(1);
            array.Add("123");
            array.Add(daysOfWeek);


            Console.Read();
        }
    }
}
