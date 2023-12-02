using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ICateringRepository
    {
        IEnumerable<Catering> GetCaterings(bool? status);
        Catering GetCateringById(int id);
        Catering GetCateringByName(string name);
        void AddCatering(Catering catering);
        void UpdateCateringById(int id, Catering catering);
        void UpdateCateringStatus(int id, bool status);



    }
}
