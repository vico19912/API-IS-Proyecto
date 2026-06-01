using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class EmpleadoProfile : Profile
{
    public EmpleadoProfile()
    {
        CreateMap<Empleado, EmpleadoDto>()
        .ForMember(dest => dest.Hospital_Nombre, opt => opt.MapFrom(src => src.Hospital.Nombre))
        .ForMember(dest => dest.Rol_Nombre, opt => opt.MapFrom(src => src.Rol.Descripcion))
        .ForMember(dest => dest.Tipo_Empleado_Nombre, opt => opt.MapFrom(src => src.TipoEmpleado.Descripcion))
        .ReverseMap();
        CreateMap<Empleado, CreateEmpleadoDto>().ReverseMap();
        CreateMap<Empleado, UpdateEmpleadoDto>().ReverseMap();
    }
}
