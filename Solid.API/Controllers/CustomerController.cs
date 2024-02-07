using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.Models;
using Solid.Core.DTOs;
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
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get(bool? status)
        {
            var list = _customerService.GetCustomers(status);
            var listDto=list.Select(c=>_mapper.Map<CustomerDto>(c)).ToList();
            return Ok(listDto);
        }
        
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer customer = _customerService.GetCustomerById(id);
            if (customer is null)
                return NotFound();
            var customerDto= _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpGet("{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            Customer customer = _customerService.GetCustomerByPhone(phone);
            if (customer is null)
                return NotFound();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerPostModel c)
        {
            var customerToAdd = _mapper.Map<Customer>(c);
          //  var addedCustomer = _customerService.AddCustomer(customerToAdd);
          //  _customerService.AddCustomer(value);
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
