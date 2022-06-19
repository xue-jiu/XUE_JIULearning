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
        public List<Customer> Customers { get; set; } = new();

        public void LoadCustomers()
        {
            using (var db = new AppDbContext())
            {
                Customers = db.Customers.Include(c => c.Appointments).ToList();
            }
        }
    }
}
