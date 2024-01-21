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
            return _context.CustomerList.Where(c => (c.Status == status || status == null));
        }


        public Customer GetCustomerById(int id) => _context.CustomerList.Find(id);


        public Customer GetCustomerByPhone(string phone) => _context.CustomerList.Find(phone);

        public Customer AddCustomer(Customer customer)
        {
            _context.CustomerList.Add(customer);
            _context.SaveChanges();
            return customer;
        }



        public Customer UpdateCustomer(int id, Customer customer)
        {
            Customer c = _context.CustomerList.Find(id);
            if (c is not null)
            {
                c.Name = customer.Name;
                c.Status = customer.Status;
                c.Adress = customer.Adress;
                c.Comment = customer.Comment;
                c.Email = customer.Email;
                c.Phone_num = customer.Phone_num;
            }  //_context.CustomerList.Remove(c);
            else
                _context.CustomerList.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomerStatus(int id, bool status)
        {
            Customer c = _context.CustomerList.Find(id);
            if (c is not null)
                _context.CustomerList.Find(id).Status = status;
            _context.SaveChanges();
            return c;
        }


    }
}
