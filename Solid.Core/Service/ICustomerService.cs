using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Service
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers(bool? status);
        Customer GetCustomerById(int id);
        Customer GetCustomerByPhone(string phone);
        void AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
        void UpdateCustomerStatus(int id, bool status);
    }
}
