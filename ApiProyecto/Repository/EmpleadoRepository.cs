using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly ApplicationDbContext _db;
    public EmpleadoRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Empleado> GetAllEmpleados()
    {
        return _db.empleado
                .Include(e => e.Hospital)
                .Include(e => e.Rol)
                .Include(e => e.TipoEmpleado)
                .OrderBy(e => e.Id_Empleado)
                .ToList();
    }
    public ICollection<Empleado> GetEmpleadoByHospitalId(int hospitalId)
    {
        return _db.empleado
                .Include(e => e.Hospital)
                .Include(e => e.Rol)
                .Include(e => e.TipoEmpleado)
                .Where(e => e.Hospital_Id == hospitalId)
                .OrderBy(e => e.Id_Empleado)
                .ToList();
    }
    public Empleado? GetEmpleadoById(int id)
    {
        return _db.empleado
                .Include(e => e.Hospital)
                .Include(e => e.Rol)
                .Include(e => e.TipoEmpleado)
                .FirstOrDefault(e => e.Id_Empleado == id);
    }
    public bool CreateEmpleado(Empleado empleado)
    {
        empleado.Fecha_Ingreso = DateTime.UtcNow;
        empleado.Fecha_Modificacion = DateTime.UtcNow;
        _db.empleado.Add(empleado);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateEmpleado(Empleado empleado)
    {
        empleado.Fecha_Modificacion = DateTime.Now;
        _db.empleado.Update(empleado);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteEmpleado(int id)
    {
        var empleado = GetEmpleadoById(id);
        if (empleado == null) return false;

        _db.empleado.Remove(empleado);
        return _db.SaveChanges() > 0;
    }
}
