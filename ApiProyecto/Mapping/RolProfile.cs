using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;
public class RolProfile : Profile
{
    public RolProfile()
    {
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Rol, CreateRolDto>().ReverseMap();
    }
}
