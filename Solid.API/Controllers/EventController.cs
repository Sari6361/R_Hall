using Microsoft.AspNetCore.Mvc;
using Solid.API.Models;
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
        public void Post([FromBody] EventPostModel e)
        {
            var eventToAdd = new Event { Id = e.Id, Date = e.Date, Start_hour = e.Start_hour, End_hour = e.End_hour, EventKind = e.EventKind, Sum = e.Sum, HasPaid = e.HasPaid, AmountOfPortions = e.AmountOfPortions, Comments = e.Comments };
            _eventService.AddEvent(eventToAdd);
        }


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event e)
        {
            var eventToUpdate = new Event { Id = e.Id, Date = e.Date, Start_hour = e.Start_hour, End_hour = e.End_hour, EventKind = e.EventKind, Sum = e.Sum, HasPaid = e.HasPaid, AmountOfPortions = e.AmountOfPortions, Comments = e.Comments };
            _eventService.UpdateEventById(id, eventToUpdate);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _eventService.DeleteEventById(id);
        }
    }
}
