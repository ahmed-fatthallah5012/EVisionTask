using AutoMapper;
using DomainModel.Models;
using Models.Models;

namespace Core.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Vehicle, VehicleModel>().ReverseMap();
        }
    }
}