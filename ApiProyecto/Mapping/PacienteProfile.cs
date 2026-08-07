using ApiProyecto.Models;
using ApiProyecto.Models.Dto;
using AutoMapper;

namespace ApiProyecto.Mapping;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<Paciente, CreatePacienteDto>().ReverseMap();
        CreateMap<CreatePacienteDto, Persona>();
        CreateMap<Paciente, PacienteDto>()
            .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => src.Persona));
    }
}
