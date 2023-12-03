using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class EventRepository : IEventRepoistory
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Event> GetEvents() => _context.EventList;

        public Event GetEventById(int id)
        {
            return _context.EventList.Find(e => e.Id == id);
        }
        public void AddEvent(Event e)
        {
            _context.EventList.Add(e);
        }


        public void UpdateEventById(int id, Event e)
        {
            Event ev = _context.EventList.Find(e => e.Id == id);
            if (ev is not null)
                _context.EventList.Remove(e);
            _context.EventList.Add(ev); 
        }
        public void DeleteEventById(int id)
        {
            Event e = _context.EventList.Find(e => e.Id == id);
            if (e is not null)
                _context.EventList.Remove(e);
        }
    }
}
