using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            var listDto = list.Select(c => _mapper.Map<CustomerDto>(c)).ToList();
            return Ok(listDto);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer is null)
                return NotFound();
            var customerDto = _mapper.Map<CustomerDto>(customer);
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
        public ActionResult Post([FromBody] CustomerPostModel c)
        {
            var customerToAdd = _mapper.Map<Customer>(c);
            var addedCustomer = _customerService.AddCustomer(customerToAdd);
            var newCustomer = _customerService.GetCustomerById(addedCustomer.Id);
            var customerDto = _mapper.Map<CustomerDto>(newCustomer);
            return Ok(customerDto);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerPostModel c)
        {
            var existCustomer = _customerService.GetCustomerById(id);
            if (existCustomer is null)
                return NotFound();
            _mapper.Map(c, existCustomer);
            _customerService.UpdateCustomer(id, existCustomer);
            return Ok(_mapper.Map<CustomerDto>(existCustomer));
        }

        [HttpPut("{id}/status")]
        public ActionResult PutStatus(int id, [FromBody] bool status)
        {

            var existCustomer = _customerService.GetCustomerById(id);
            if (existCustomer is null)
                return NotFound();
            existCustomer.Status = status;
            _customerService.UpdateCustomerStatus(id, status);
            return Ok(_mapper.Map<CustomerDto>(existCustomer));
        }
    }
}
