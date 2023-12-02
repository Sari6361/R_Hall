using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class EventRepository:IEventRepoistory
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }
    }
}
