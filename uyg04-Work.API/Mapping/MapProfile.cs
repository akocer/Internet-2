using AutoMapper;
using uyg04_Work.API.DTOs;
using uyg04_Work.API.Models;

namespace uyg04_Work.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<WorkStep, WorkStepDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
