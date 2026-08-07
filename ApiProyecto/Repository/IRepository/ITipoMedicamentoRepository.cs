using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface ITipoMedicamentoRepository
{
    ICollection<TipoMedicamento> GetAll();
    TipoMedicamento? GetById(int id);
    bool Create(TipoMedicamento tipo);
    bool Update(TipoMedicamento tipo);
    bool Delete(int id);
}
