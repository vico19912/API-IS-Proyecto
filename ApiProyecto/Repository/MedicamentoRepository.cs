using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class MedicamentoRepository : IMedicamentoRepository
{
    private readonly ApplicationDbContext _db;
    public MedicamentoRepository(ApplicationDbContext db) => _db = db;

    public ICollection<Medicamento> GetAll() =>
        _db.medicamento
           .Include(m => m.TipoMedicamento)
           .OrderBy(m => m.Id_Medicamento)
           .AsNoTracking()
           .ToList();

    public Medicamento? GetById(int id) =>
        _db.medicamento
           .Include(m => m.TipoMedicamento)
           .FirstOrDefault(m => m.Id_Medicamento == id);

    public bool Create(Medicamento medicamento)
    {
        _db.medicamento.Add(medicamento);
        return _db.SaveChanges() > 0;
    }

    public bool Update(Medicamento medicamento)
    {
        var existing = _db.medicamento.FirstOrDefault(m => m.Id_Medicamento == medicamento.Id_Medicamento);
        if (existing == null) return false;
        existing.Descripcion = medicamento.Descripcion;
        existing.Tipo_Medicamento_Id = medicamento.Tipo_Medicamento_Id;
        return _db.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var m = _db.medicamento.FirstOrDefault(m => m.Id_Medicamento == id);
        if (m == null) return false;
        _db.medicamento.Remove(m);
        return _db.SaveChanges() > 0;
    }
}
