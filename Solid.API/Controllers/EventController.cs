using Microsoft.AspNetCore.Mvc;
using Solid.API.Models;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Service;
using Solid.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
        // GET: api/<EventController>
        [HttpGet]
        public ActionResult< IEnumerable<Event>> Get()
        {
            var list = _eventService.GetEvents();
            var listDto = list.Select(e=> _mapper.Map<EventDto>(e)).ToList();
            return Ok(listDto);
        }


        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var eve=  _eventService.GetEventById(id);
            if (eve is null)
                return NotFound();
            var eveDto=_mapper.Map<EventDto>(eve);
            return Ok(eveDto);
        }


        // POST api/<EventController>
        [HttpPost]
        public ActionResult Post([FromBody] EventPostModel e)
        {
            var eventToAdd = _mapper.Map<Event>(e);
            var addedEvent= _eventService.AddEvent(eventToAdd);
            var newEvent = _eventService.GetEventById(addedEvent.Id);
            var eventDto = _mapper.Map<EventDto>(newEvent);
            return Ok(eventDto); 
        }


        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EventPostModel e)
        {
            var existEvent=_eventService.GetEventById(id);
            if (existEvent is null)
                return NotFound();
            _mapper.Map(e, existEvent);
            _eventService.UpdateEventById(id, existEvent);
          return Ok(_mapper.Map<EventDto>(e));
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var e = _eventService.GetEventById(id);
            if (e is null)
                return NotFound();
            _eventService.DeleteEventById(id);
            return NoContent();
        }
    }
}
