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

            // 12-5
            var daysOfWeek4 = new List<string>(daysOfWeek3);
            var daysOfWeek5 = new List<string>(daysOfWeek);
            var daysOfWeek6 = new List<string>(7);
            Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");
            daysOfWeek6.Add("Monday");
            daysOfWeek6.Add("Tuesday");
            daysOfWeek6.Add("Wendesday");
            daysOfWeek6.Add("Thursday");
            daysOfWeek6.Add("Friday");
            daysOfWeek6.Add("Saturday");
            daysOfWeek6.Add("Sunday");
            Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");
            daysOfWeek6.Add("Sunday");
            Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");

            List<string> daysOfWeek7 = new List<string>
            {
                "Tuesday",
                "Monday",
                "Wendesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };


            // Add AddRange
            daysOfWeek7.AddRange(daysOfWeek); //array
            daysOfWeek7.AddRange(daysOfWeek3); //List
            Console.WriteLine($"{daysOfWeek7.Count} / {daysOfWeek7.Capacity}");

            // Insert InsertRange
            daysOfWeek7.InsertRange(2, daysOfWeek);
            daysOfWeek7.Insert(2, "随便");
            Console.WriteLine(string.Join(", ", daysOfWeek7));

            daysOfWeek6.InsertRange(0, daysOfWeek7);
            daysOfWeek7.AddRange(daysOfWeek6);

            // 删除数据 RemoveAt RemoveRange
            daysOfWeek7.RemoveAt(0);
            daysOfWeek7.RemoveAt(2);
            daysOfWeek7.RemoveRange(2, 6);
            daysOfWeek7.Remove("Monday");
            daysOfWeek7.RemoveAll( i => i == "Monday");
            daysOfWeek7.RemoveAll(i => i.Contains("day"));
            Console.WriteLine(string.Join(", ", daysOfWeek7));


            Console.Read();
        }
    }
}
