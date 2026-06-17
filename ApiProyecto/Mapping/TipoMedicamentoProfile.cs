using AutoMapper;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Mapping;

public class TipoMedicamentoProfile : Profile
{
    public TipoMedicamentoProfile()
    {
        CreateMap<TipoMedicamento, TipoMedicamentoDto>();
        CreateMap<CreateTipoMedicamentoDto, TipoMedicamento>();
    }
}
