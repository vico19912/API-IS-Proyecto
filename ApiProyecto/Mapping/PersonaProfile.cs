using AutoMapper;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Mapping;

public class PersonaProfile : Profile
{
    public PersonaProfile()
    {
        CreateMap<Persona, CreatePersonaDto>().ReverseMap();
    }
}
