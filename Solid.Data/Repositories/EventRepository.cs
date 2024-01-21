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
            return _context.EventList.Find(id);
        }
        public Event AddEvent(Event e)
        {
            _context.EventList.Add(e);
            _context.SaveChanges();
            return e;
        }


        public Event UpdateEventById(int id, Event e)
        {
            Event ev = _context.EventList.Find(id);
            if (ev is not null)
            {
                ev.Date = e.Date;
                ev.Start_hour = e.Start_hour;
                ev.End_hour = e.End_hour;
                ev.EventKind = e.EventKind;
                ev.Sum = e.Sum;
                ev.HasPaid = e.HasPaid;
                ev.CateringId = e.CateringId;
                ev.CustomerId = e.CustomerId;
                ev.AmountOfPortions = e.AmountOfPortions;
                ev.Comments = e.Comments;
            }
            else
                _context.EventList.Add(e);
            _context.SaveChanges();
            return ev;
        }
        public void DeleteEventById(int id)
        {
            Event e = _context.EventList.Find(id);
            if (e is not null)
                _context.EventList.Remove(e);
            _context.SaveChanges();
        }
    }
}
