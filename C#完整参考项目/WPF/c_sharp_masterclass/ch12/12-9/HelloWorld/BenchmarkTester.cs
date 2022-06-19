using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    [MemoryDiagnoser]
    public class BenchmarkTester
    {
        [Benchmark]
        public void ProcessCustomer()
        {
            var customers = GetCustomers(1000000);
            foreach (var c in customers)
            {
                if (c.Id < 1000)
                {
                    Console.WriteLine($"客户id {c.Id}, 客户姓名: {c.Name}");
                }
                else
                {
                    break;
                }
            }
        }

        [Benchmark]
        public void ProcessCustomerYield()
        {
            var customers = GetCustomersYield(1000000);
            foreach (var c in customers)
            {
                if (c.Id < 1000)
                {
                    Console.WriteLine($"客户id {c.Id}, 客户姓名: {c.Name}");
                }
                else
                {
                    break;
                }
            }
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
            for (int i = 0; i < count; i++)
            {
                customers.Add(new Customer(i, $"阿莱克斯{i}", "广州"));
            }
            return customers;
        }
    }
}
