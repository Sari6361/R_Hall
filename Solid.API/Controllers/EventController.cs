using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IDataContext _dataContext;
        public EventController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get() => _dataContext.Events;


        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
                return NotFound();
            return Ok(eve);
        }


        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event value) => _dataContext.Events.Add(value);


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event value)
        {
            Event eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
                return NotFound();
            _dataContext.Events.Remove(eve);
            _dataContext.Events.Add(value);
            return Ok();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Event eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve is null)
                return NotFound();
            _dataContext.Events.Remove(eve);
            _dataContext.Events.Add(eve);
            return Ok();
        }
    }
}
