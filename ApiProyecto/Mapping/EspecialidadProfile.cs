using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class EspecialidadProfile : Profile
{
    public EspecialidadProfile()
    {
        CreateMap<Especialidad, EspecialidadDto>().ReverseMap();
        CreateMap<Especialidad, CreateEspecialidadDto>().ReverseMap();
    }
}
