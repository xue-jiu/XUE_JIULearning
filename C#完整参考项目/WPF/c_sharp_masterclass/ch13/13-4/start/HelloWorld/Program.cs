using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Alex", "广州"),
                new Customer(2, "Scott", "北京"),
                new Customer(3, "Chris", "上海"),
                new Customer(4, "Anna", "广州"),
                new Customer(5, "Angie", "深圳"),
                new Customer(6, "Bob", "武汉"),
                new Customer(7, "Tony", "深圳")
            };

            Console.Read();
        }
    }
    public class Customer
    {
        public Customer(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
