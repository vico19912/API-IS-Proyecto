using AutoMapper;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Mapping;

public class PermisoProfile : Profile
{
    public PermisoProfile()
    {
        CreateMap<Permiso, PermisoDto>().ReverseMap();
        CreateMap<Permiso, CreatePermisoDto>().ReverseMap();
    }
}
