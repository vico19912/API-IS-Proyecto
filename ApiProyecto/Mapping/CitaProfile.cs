using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class CitaProfile : Profile
{
    public CitaProfile()
    {
        CreateMap<Cita, CitaDto>()
            .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente))
            .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor));
        CreateMap<CreateCitaDto, Cita>();
        CreateMap<UpdateCitaDto, Cita>();
    }
}
