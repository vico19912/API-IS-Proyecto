using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class DiagnosticoProfile : Profile
{
    public DiagnosticoProfile()
    {
        CreateMap<Diagnostico, DiagnosticoDto>()
            .ForMember(dest => dest.Cita, opt => opt.MapFrom(src => src.Cita));
        CreateMap<CreateDiagnosticoDto, Diagnostico>();
    }
}
