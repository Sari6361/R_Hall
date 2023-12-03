using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get() => _eventService.GetEvents();   


        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event eve = _eventService.GetEventById(id);
            if (eve is null)
                return NotFound();
            return Ok(eve);
        }


        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event value) =>_eventService.AddEvent(value);   


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            _eventService.UpdateEventById(id, value);  
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _eventService.DeleteEventById(id);
        }
    }
}
