using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CMS.Models;

namespace WPF_CMS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public List<Customer> Customers { get; set; } = new();
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = new();
        public ObservableCollection<AppointmentViewModel> Appointments { get; set; } = new();

        private CustomerViewModel _selectedCustomer;

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer; 
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged(nameof(SelectedCustomer));
                    LoadAppointments(SelectedCustomer.Id);
                }
            }
        }

        public void LoadCustomers()
        {
            Customers.Clear();
            using (var db = new AppDbContext())
            {
                // Select * from Customers as c join Appointments as a on c.Id = a. CustomerId
                var customers = db.Customers
                    //.Include(c => c.Appointments)
                    .ToList();

                foreach (var c in customers)
                {
                    Customers.Add(new CustomerViewModel(c));
                }
            }
        }

        public void ClearSelectedCustomer()
        {
            _selectedCustomer = null;
            RaisePropertyChanged(nameof(SelectedCustomer));
        }

        public void SaveCustomer(string name, string idNumber, string address)
        {
            if(SelectedCustomer != null)
            {
                // 更新客户数据
                using (var db = new AppDbContext())
                {
                    var customer = db.Customers.Where(c => c.Id == SelectedCustomer.Id).FirstOrDefault();
                    customer.Name = name;
                    customer.IdNnumber = idNumber;
                    customer.Address = address;
                    db.SaveChanges();
                }
            }
            else
            {
                // 添加新客户
                using (var db = new AppDbContext())
                {
                    var newCustomer = new Customer()
                    {
                        Name = name,
                        IdNnumber = idNumber,
                        Address = address
                    };
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                }
                LoadCustomers();
            }
        }

        public void LoadAppointments(int customerId)
        {
            Appointments.Clear();
            using (var db = new AppDbContext())
            {
                var appointments = db.Appointments.Where(a => a.CustomerId == customerId).ToList();
                foreach(var a in appointments)
                {
                    Appointments.Add(new AppointmentViewModel(a));
                }
            }
        }
    
        public void AddAppointment(DateTime selectedDate)
        {
            if (SelectedCustomer == null)
            {
                return;
            }

            using (var db = new AppDbContext())
            {
                var newAppointment = new Appointment()
                {
                    Time = selectedDate,
                    CustomerId = SelectedCustomer.Id
                };
                db.Appointments.Add(newAppointment);
                db.SaveChanges();
            }
            LoadAppointments(SelectedCustomer.Id);
        }
    }
}
