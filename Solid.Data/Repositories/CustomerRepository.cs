using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetCustomers(bool? status)
        {
            return _context.CustomerList.Where(c => (c.Status == status || status is null));
        }


        public Customer GetCustomerById(int id) => _context.CustomerList.Find(c => c.Id == id);


        public Customer GetCustomerByPhone(string phone) => _context.CustomerList.Find(c => c.Phone_num == phone);

        public void AddCustomer(Customer customer) => _context.CustomerList.Add(customer);



        public void UpdateCustomer(int id, Customer customer)
        {
            Customer c = _context.CustomerList.Find(c => c.Id == id);
            if (c is not null)
                _context.CustomerList.Remove(c);
            _context.CustomerList.Add(customer);
        }

        public void UpdateCustomerStatus(int id, bool status)
        {
            Customer c = _context.CustomerList.Find(c => c.Id == id);
            if (c is not null)
                _context.CustomerList.Find(c => c.Id == id).Status = status;
        }


    }
}
