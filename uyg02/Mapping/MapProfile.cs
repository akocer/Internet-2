using AutoMapper;
using System.Runtime.CompilerServices;
using uyg02.Dtos;
using uyg02.Models;

namespace uyg02.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }

    }
}
