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
            .ForMember(dest => dest.DNI, opt => opt.MapFrom(src => src.Persona.DNI))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
            .ForMember(dest => dest.Nombre_2, opt => opt.MapFrom(src => src.Persona.Nombre_2))
            .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Persona.Apellido))
            .ForMember(dest => dest.Apellido_2, opt => opt.MapFrom(src => src.Persona.Apellido_2))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Persona.Telefono))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Persona.Correo))
            .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Persona.Sexo))
            .ForMember(dest => dest.Fecha_Nacimiento, opt => opt.MapFrom(src => src.Persona.Fecha_Nacimiento));
    }
}
