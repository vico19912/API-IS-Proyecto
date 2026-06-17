using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class FacturaRepository : IFacturaRepository
{
    private readonly ApplicationDbContext _db;
    public FacturaRepository(ApplicationDbContext db) => _db = db;

    public ICollection<Factura> GetAll() =>
        _db.factura
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Paciente)
                   .ThenInclude(p => p!.Persona)
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Doctor)
                   .ThenInclude(d => d!.Persona)
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Doctor)
                   .ThenInclude(d => d!.Especialidad)
           .OrderByDescending(f => f.Fecha_Creacion)
           .AsNoTracking()
           .ToList();

    public Factura? GetById(int id) =>
        _db.factura
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Paciente)
                   .ThenInclude(p => p!.Persona)
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Doctor)
                   .ThenInclude(d => d!.Persona)
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Doctor)
                   .ThenInclude(d => d!.Especialidad)
           .FirstOrDefault(f => f.Id_Factura == id);

    public ICollection<Factura> GetByCitaId(int citaId) =>
        _db.factura
           .Include(f => f.Cita)
               .ThenInclude(c => c!.Paciente)
                   .ThenInclude(p => p!.Persona)
           .Where(f => f.Cita_Id == citaId)
           .ToList();

    public bool Create(Factura factura)
    {
        factura.Fecha_Creacion = DateTime.UtcNow;
        _db.factura.Add(factura);
        return _db.SaveChanges() > 0;
    }

    public bool Update(Factura factura)
    {
        var existing = _db.factura.FirstOrDefault(f => f.Id_Factura == factura.Id_Factura);
        if (existing == null) return false;
        existing.Monto = factura.Monto;
        existing.Metodo_Pago = factura.Metodo_Pago;
        existing.Estado = factura.Estado;
        existing.Cita_Id = factura.Cita_Id;
        return _db.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var f = _db.factura.FirstOrDefault(f => f.Id_Factura == id);
        if (f == null) return false;
        _db.factura.Remove(f);
        return _db.SaveChanges() > 0;
    }
}
