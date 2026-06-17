using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IMedicamentoRepository
{
    ICollection<Medicamento> GetAll();
    Medicamento? GetById(int id);
    bool Create(Medicamento medicamento);
    bool Update(Medicamento medicamento);
    bool Delete(int id);
}
