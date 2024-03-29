﻿using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Service
{
    public interface ICateringService
    {
        IEnumerable<Catering> GetCaterings(bool? status);
        Catering GetCateringById(int id);
        Catering GetCateringByName(string name);
        Catering AddCatering(Catering catering);
        void UpdateCateringById(int id, Catering catering);
        void UpdateCateringStatus(int id, bool status);
    }
}
