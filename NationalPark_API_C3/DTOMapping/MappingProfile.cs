using AutoMapper;
using NationalPark_API_C3.Models;
using NationalPark_API_C3.Models.DTOs;

namespace NationalPark_API_C3.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail,TrailDto>().ReverseMap();
        }
    }
}           //DB---Model---Repository---Dto---Client   //** Display/Find
            //Client---Dto---Repository---Model---DB   //** Save/Update

