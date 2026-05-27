using AutoMapper;
using ApiProyecto.Models.Dto;
using ApiProyecto.Models;

namespace ApiProyecto.Mapping;

public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Hospital, HospitalDto>().ReverseMap();
        CreateMap<Hospital, CreateHospitalDto>().ReverseMap();
    }
}
