using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class TipoEmpleadoRepository : ITipoEmpleadoRepository
{
    private readonly ApplicationDbContext _db;

    public TipoEmpleadoRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<TipoEmpleado> GetAllTipoEmpleados()
    {
        return _db.tipoempleado.OrderBy(te => te.Id_Tipo).ToList();
    }
    public TipoEmpleado? GetTipoEmpleadoById(int id)
    {
        return _db.tipoempleado.AsNoTracking().FirstOrDefault(te => te.Id_Tipo == id);
    }
    public TipoEmpleado? GetTipoEmpleadoByDescripcion(string descripcion)
    {
        return _db.tipoempleado.AsNoTracking().FirstOrDefault(te => te.Descripcion.ToLower() == descripcion.ToLower());
    }
    public bool CreateTipoEmpleado(TipoEmpleado tipoEmpleado)
    {
        tipoEmpleado.Fecha_Creacion = DateTime.Now;
        tipoEmpleado.Fecha_Modificacion = DateTime.Now;
        _db.tipoempleado.Add(tipoEmpleado);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateTipoEmpleado(TipoEmpleado tipoEmpleado)
    {
        tipoEmpleado.Fecha_Modificacion = DateTime.Now;
        _db.tipoempleado.Update(tipoEmpleado);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteTipoEmpleadoById(int id)
    {
        var tipoEmpleado = GetTipoEmpleadoById(id);
        if (tipoEmpleado == null) return false;

        _db.tipoempleado.Remove(tipoEmpleado);
        return _db.SaveChanges() > 0;
    }
}
