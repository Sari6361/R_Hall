using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class CateringRepository : ICateringRepository
    {
        private readonly DataContext _context;

        public CateringRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Catering> GetCaterings(bool? status)
        {
            return _context.CateringList.Where(c => (c.Status == status || status is null));
        }

        public Catering GetCateringById(int id) => _context.CateringList.Find(c => c.Id == id);

        public Catering GetCateringByName(string name) => _context.CateringList.Find(c => c.Name.Equals(name));

        public void AddCatering(Catering catering) => _context.CateringList.Add(catering);

        public void UpdateCateringById(int id, Catering catering)
        {
            Catering c = _context.CateringList.Find(c => c.Id == id);
            _context.CateringList.Remove(c);
            _context.CateringList.Add(catering);
        }

        public void UpdateCateringStatus(int id, bool status)
        {
            Catering catering = _context.CateringList.Find(c => c.Id == id);
            if (catering is not null)
                _context.CateringList.Find(c => c.Id == id).Status = status;
        }
    }
}
