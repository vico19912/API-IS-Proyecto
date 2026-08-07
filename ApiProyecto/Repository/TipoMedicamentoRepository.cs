using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;

namespace ApiProyecto.Repository;

public class TipoMedicamentoRepository : ITipoMedicamentoRepository
{
    private readonly ApplicationDbContext _db;
    public TipoMedicamentoRepository(ApplicationDbContext db) => _db = db;

    public ICollection<TipoMedicamento> GetAll() =>
        _db.tipoMedicamento.OrderBy(t => t.Id_Tipo).ToList();

    public TipoMedicamento? GetById(int id) =>
        _db.tipoMedicamento.FirstOrDefault(t => t.Id_Tipo == id);

    public bool Create(TipoMedicamento tipo)
    {
        _db.tipoMedicamento.Add(tipo);
        return _db.SaveChanges() > 0;
    }

    public bool Update(TipoMedicamento tipo)
    {
        var existing = _db.tipoMedicamento.FirstOrDefault(t => t.Id_Tipo == tipo.Id_Tipo);
        if (existing == null) return false;
        existing.Descripcion = tipo.Descripcion;
        return _db.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var tipo = GetById(id);
        if (tipo == null) return false;
        _db.tipoMedicamento.Remove(tipo);
        return _db.SaveChanges() > 0;
    }
}
