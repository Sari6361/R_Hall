using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(bool ?status);
        Customer GetCustomerById(int id);
        Customer GetCustomerByPhone(string phone);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        Customer UpdateCustomerStatus(int id, bool status);
    }
}
