using AutoMapper;
using ApiProyecto.Models;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Mapping;

public class MedicamentoProfile : Profile
{
    public MedicamentoProfile()
    {
        CreateMap<Medicamento, MedicamentoDto>()
            .ForMember(d => d.Tipo_Nombre,
                o => o.MapFrom(s => s.TipoMedicamento != null ? s.TipoMedicamento.Descripcion : string.Empty));
        CreateMap<CreateMedicamentoDto, Medicamento>();
    }
}
