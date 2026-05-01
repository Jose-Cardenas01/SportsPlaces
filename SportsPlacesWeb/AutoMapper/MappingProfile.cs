using AutoMapper;
using SportsPlacesWeb.Data.Entity;
using SportsPlacesWeb.DTOs;

namespace SportsPlacesWeb.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Escenarios, EscenarioDTO>().ReverseMap();
        }
    }
}
