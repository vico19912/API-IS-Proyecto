using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class TipoEmpleadoProfile : Profile
{
    public TipoEmpleadoProfile()
    {
        CreateMap<TipoEmpleado, TipoEmpleadoDto>().ReverseMap();
        CreateMap<TipoEmpleado, CreateTipoEmpleadoDto>().ReverseMap();
    }

}
