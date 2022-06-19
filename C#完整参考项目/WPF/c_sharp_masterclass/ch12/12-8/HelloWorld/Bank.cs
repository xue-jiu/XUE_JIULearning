using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Bank : IEnumerable<Customer>
    {
        public MyList<Customer> Customers { get; set; } = new MyList<Customer>(4);

        public Bank()
        {
            Customers.Add(new Customer(1, "阿莱克斯", "广州"));
            Customers.Add(new Customer(2, "莱克斯", "北京"));
            Customers.Add(new Customer(3, "克斯", "上海"));
            Customers.Add(new Customer(4, "斯", "深圳"));
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return Customers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
