using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get(bool? status)=>_customerService.GetCustomers(status);
        
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);
            if (customer is null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            Customer customer = _customerService.GetCustomerByPhone(phone);
            if (customer is null)
                return NotFound();
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            _customerService.AddCustomer(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
             _customerService.UpdateCustomer(id, value);
           
        }

        [HttpPut("{id}/status")]
        public void PutStatus(int id, [FromBody] bool status)
        {
            _customerService.UpdateCustomerStatus(id, status);  
        }
    }
}
