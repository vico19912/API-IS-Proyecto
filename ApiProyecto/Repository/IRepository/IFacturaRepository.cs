using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IFacturaRepository
{
    ICollection<Factura> GetAll();
    Factura? GetById(int id);
    ICollection<Factura> GetByCitaId(int citaId);
    bool Create(Factura factura);
    bool Update(Factura factura);
    bool Delete(int id);
}
