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
        Catering AddCatering(Catering catering);
        Catering UpdateCateringById(int id, Catering catering);
        Catering UpdateCateringStatus(int id, bool status);



    }
}
