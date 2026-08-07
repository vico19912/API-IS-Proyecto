using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDto>()
        .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => src.Persona))
        .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => src.Empleado))
        .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src => src.Especialidad))
        .ReverseMap();
        CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
        CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();
    }
}
