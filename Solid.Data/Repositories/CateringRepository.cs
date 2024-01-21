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
            return _context.CateringList.Where(c => (c.Status == status || status == null));
        }

        public Catering GetCateringById(int id) => _context.CateringList.Find(id);

        public Catering GetCateringByName(string name) => _context.CateringList.First(c => c.Name.Equals(name));

        public Catering AddCatering(Catering catering)
        {
            _context?.CateringList?.Add(catering);
            _context.SaveChanges();
            return catering;
        }

        public Catering UpdateCateringById(int id, Catering catering)
        {
            Catering c = _context.CateringList.Find(id);
            if (c is not null)
            {
                c.Name = catering.Name;
                c.TypeFood = catering.TypeFood;
                c.PriceForPlate = catering.PriceForPlate;
                c.Status = catering.Status;
            }
            _context.CateringList.Add(catering);
            _context.SaveChanges();
            return catering;
        }

        public Catering UpdateCateringStatus(int id, bool status)
        {
            Catering catering = _context.CateringList.Find(id);
            if (catering is not null)
                _context.CateringList.Find(id).Status = status;
            _context.SaveChanges();
            return catering;
        }
    }
}
