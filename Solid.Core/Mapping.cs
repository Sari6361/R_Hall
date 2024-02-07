using AutoMapper;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Catering, CateringDto>().ReverseMap();
        }
    }
}
