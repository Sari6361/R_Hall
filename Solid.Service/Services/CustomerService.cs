using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customer> GetCustomers(bool? status) => _customerRepository.GetCustomers(status);

        public Customer GetCustomerById(int id) => _customerRepository.GetCustomerById(id);

        public Customer GetCustomerByPhone(string phone) => _customerRepository.GetCustomerByPhone(phone);

        public void AddCustomer(Customer customer) => _customerRepository.AddCustomer(customer);

        public void UpdateCustomer(int id, Customer customer) => _customerRepository.UpdateCustomer(id, customer);

        public void UpdateCustomerStatus(int id, bool status) => _customerRepository.UpdateCustomerStatus(id, status);

    }
}
