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
    public class EventService : IEventService
    {
        private readonly IEventRepoistory _eventRepoistory;

        public EventService(IEventRepoistory eventRepoistory)
        {
            _eventRepoistory = eventRepoistory;
        }

        public IEnumerable<Event> GetEvents()=>_eventRepoistory.GetEvents();
        
        public Event GetEventById(int id)=>_eventRepoistory.GetEventById(id);
        
        public Event AddEvent(Event e)=>_eventRepoistory.AddEvent(e);
       
        public void UpdateEventById(int id, Event e)=>_eventRepoistory.UpdateEventById(id, e);  
        
        public void DeleteEventById(int id)=>_eventRepoistory.DeleteEventById(id); 
       
    }
}
