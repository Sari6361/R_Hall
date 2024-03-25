using AutoMapper;
using Solid.API.Models;
using Solid.Core.Entities;

namespace Solid.API.Mapping
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Customer, CustomerPostModel>().ReverseMap();
            CreateMap<Event, EventPostModel>().ReverseMap();
        }
    }
}
 