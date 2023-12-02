using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateringController : ControllerBase
    {
        private readonly ICateringService _cateringService;
        public CateringController(ICateringService cateringService)
        {
            _cateringService = cateringService;
        }
        // GET: api/<CateringController>
        [HttpGet]
        public IEnumerable<Catering> Get(bool? status) =>_cateringService.GetCaterings(status);

        // GET api/<CateringController>/5
        [HttpGet("{id}/id")]
        public IActionResult Get(int id) {
           Catering c= _cateringService.GetCateringById(id); 
            if(c == null)
                return NotFound();
            return Ok(c);   
        }


        [HttpGet("{name}/name")]
        public IActionResult Get(string name)
        {
            Catering c = _cateringService.GetCateringByName(name);
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        // POST api/<CateringController>
        [HttpPost]
        public void Post([FromBody] Catering value)=>_cateringService.AddCatering(value);
       

        // PUT api/<CateringController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Catering catering)=>_cateringService.UpdateCateringById(id, catering);

        [HttpPut("{id}/status")]
        public void PutStatus(int id, [FromBody] bool status)
        {
            _cateringService.UpdateCateringStatus(id, status);
        }
    }
}
