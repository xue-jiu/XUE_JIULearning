using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] daysOfWeek =
            //{
            //    "Tuesday",
            //    "Monday",
            //    "Wendesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};

            //foreach(var day in daysOfWeek)
            //{
            //    Console.WriteLine(day);
            //}

            //// 零索引 0-indexed
            //Console.WriteLine(daysOfWeek[0]);
            //Console.WriteLine(daysOfWeek[1]);
            //Console.WriteLine(daysOfWeek[6]);

            //// 安全
            ////Console.WriteLine(daysOfWeek[7]);

            //// 固定长度
            //string[] daysOfWeek2 = new string[7];
            //daysOfWeek2[0] = "Monday";
            //daysOfWeek2[1] = "Tuesday";
            //daysOfWeek2[2] = "Wendesday";
            //daysOfWeek2[3] = "Thursday";
            //daysOfWeek2[4] = "Friday";
            //daysOfWeek2[5] = "Saturday";
            //daysOfWeek2[6] = "Sunday";

            //// 12-4 List 列表
            //IList<string> daysOfWeek3 = new List<string>();
            //daysOfWeek3.Add("Monday");
            //daysOfWeek3.Add("Tuesday");
            //daysOfWeek3.Add("Wendesday");
            //daysOfWeek3.Add("Thursday");
            //daysOfWeek3.Add("Friday");
            //daysOfWeek3.Add("Saturday");
            //daysOfWeek3.Add("Sunday");
            //daysOfWeek3.Add("Sunday");
            //daysOfWeek3.Add("Sunday");
            //daysOfWeek3.Add("Sunday");
            //daysOfWeek3.Add("Sunday");
            //daysOfWeek3.Add("Sunday");

            //// ArrayList
            //var array = new ArrayList();
            //array.Add(1);
            //array.Add("123");
            //array.Add(daysOfWeek);

            //// 12-5
            //var daysOfWeek4 = new List<string>(daysOfWeek3);
            //var daysOfWeek5 = new List<string>(daysOfWeek);
            //var daysOfWeek6 = new List<string>(7);
            //Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");
            //daysOfWeek6.Add("Monday");
            //daysOfWeek6.Add("Tuesday");
            //daysOfWeek6.Add("Wendesday");
            //daysOfWeek6.Add("Thursday");
            //daysOfWeek6.Add("Friday");
            //daysOfWeek6.Add("Saturday");
            //daysOfWeek6.Add("Sunday");
            //Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");
            //daysOfWeek6.Add("Sunday");
            //Console.WriteLine($"{daysOfWeek6.Count} / {daysOfWeek6.Capacity}");

            //List<string> daysOfWeek7 = new List<string>
            //{
            //    "Tuesday",
            //    "Monday",
            //    "Wendesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};


            //// Add AddRange
            //daysOfWeek7.AddRange(daysOfWeek); //array
            //daysOfWeek7.AddRange(daysOfWeek3); //List
            //Console.WriteLine($"{daysOfWeek7.Count} / {daysOfWeek7.Capacity}");

            //// Insert InsertRange
            //daysOfWeek7.InsertRange(2, daysOfWeek);
            //daysOfWeek7.Insert(2, "随便");
            //Console.WriteLine(string.Join(", ", daysOfWeek7));

            //daysOfWeek6.InsertRange(0, daysOfWeek7);
            //daysOfWeek7.AddRange(daysOfWeek6);

            //// 删除数据 RemoveAt RemoveRange
            //daysOfWeek7.RemoveAt(0);
            //daysOfWeek7.RemoveAt(2);
            //daysOfWeek7.RemoveRange(2, 6);
            //daysOfWeek7.Remove("Monday");
            //daysOfWeek7.RemoveAll( i => i == "Monday");
            //daysOfWeek7.RemoveAll(i => i.Contains("day"));
            //Console.WriteLine(string.Join(", ", daysOfWeek7));

            //// 12-6 读取数据
            //var a = daysOfWeek6.Count;
            //var b = daysOfWeek6.Capacity;

            //// 索引器
            //var c = daysOfWeek6[3];

            //// 迭代器
            //List<string>.Enumerator enumerator = daysOfWeek6.GetEnumerator();
            ////Console.WriteLine(enumerator.Current);
            ////while(enumerator.MoveNext())
            ////{
            ////    Console.WriteLine(enumerator.Current);
            ////}

            //foreach (var day in daysOfWeek6)
            //{
            //    //day = "some day";
            //    Console.WriteLine(day);
            //    //daysOfWeek6.Add("one day");
            //}

            ////for(int i=0; i<daysOfWeek6.Count-1; i++)
            ////{
            ////    Console.WriteLine(daysOfWeek6[i]);
            ////    daysOfWeek6.Add("one day");
            ////}

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer(1, "阿莱克斯", "广州"));
            //customers.Add(new Customer(2, "莱克斯", "北京"));
            //customers.Add(new Customer(3, "克斯", "上海"));
            //customers.Add(new Customer(4, "斯", "深圳"));

            //foreach(var customer in customers)
            //{
            //    customer.Name = "123";
            //    Console.WriteLine(customer.Name);
            //}

            //IEnumerable<T>
            //IEnumerator<T>
            //var bank = new Bank();
            //foreach(var c in bank)
            //{
            //    Console.WriteLine(c.Name);
            //}

            // yield retun
            var customers = GetCustomersYield(1000000);
            foreach (var c in customers)
            {
                if (c.Id < 3)
                {
                    Console.WriteLine($"客户id {c.Id}, 客户姓名: {c.Name}");
                }
                else
                {
                    break;
                }
            }

            //foreach (var i in CreateEnumerable())
            //{
            //    Console.WriteLine(i);
            //}

            Console.Read();
        }

        static IEnumerable<int> CreateEnumerable()
        {
            yield return 3;
            yield return 2;
            yield return 1;
        }

        static IEnumerable<Customer> GetCustomersYield(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Customer(i, $"阿莱克斯{i}", "广州");
            }
        }

        static IEnumerable<Customer> GetCustomers(int count)
        {
            var customers = new List<Customer>();
            for(int i=0; i<count; i++)
            {
                customers.Add(new Customer(i, $"阿莱克斯{i}", "广州"));
            }
            return customers;
        }
    }
}
