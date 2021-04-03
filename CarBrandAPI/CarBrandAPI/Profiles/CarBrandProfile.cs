using AutoMapper;
using CarBrandAPI.DTO;
using CarBrandAPI.Models;

namespace CarBrandAPI.Profiles
{
    public class CarBrandProfile : Profile
    {
        public CarBrandProfile()
        {
            CreateMap<CarBrand, CarBrandDTO>().ReverseMap();
        }
    }
}
