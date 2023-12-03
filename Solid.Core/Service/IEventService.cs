using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Service
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        Event GetEventById(int id);
        void AddEvent(Event e);
        void UpdateEventById(int id, Event e);
        void DeleteEventById(int id);
    }
}
