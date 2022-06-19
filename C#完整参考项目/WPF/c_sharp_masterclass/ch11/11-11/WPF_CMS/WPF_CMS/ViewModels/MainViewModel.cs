using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CMS.Models;

namespace WPF_CMS.ViewModels
{
    public class MainViewModel
    {
        //public List<Customer> Customers { get; set; } = new();
        public List<CustomerViewModel> Customers { get; set; } = new();
        public List<AppointmentViewModel> Appointments { get; set; } = new();

        private CustomerViewModel _selectedCustomer;
        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer; set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                }
            }
        }

        public void LoadCustomers()
        {
            using (var db = new AppDbContext())
            {
                // Select * from Customers as c join Appointments as a on c.Id = a. CustomerId
                var customers = db.Customers
                    //.Include(c => c.Appointments)
                    .ToList();

                foreach(var c in customers)
                {
                    Customers.Add(new CustomerViewModel(c));
                }
            }
        }
    }
}
