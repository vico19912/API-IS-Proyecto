using AutoMapper;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Mapping;

public class FacturaProfile : Profile
{
    public FacturaProfile()
    {
        CreateMap<Factura, FacturaDto>()
            .ForMember(d => d.Cita, o => o.MapFrom(s => s.Cita));
        CreateMap<CreateFacturaDto, Factura>();
    }
}
