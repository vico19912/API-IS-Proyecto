using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiProyecto.Repository;

public class RolRepository : IRolRepository
{
    private readonly ApplicationDbContext _db;

    public RolRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Rol> GetAllRoles()
    {
        return _db.rol.OrderBy(r => r.Id_Rol).ToList();
    }

    public Rol? GetRolById(int id)
    {
        return _db.rol.AsNoTracking().FirstOrDefault(r => r.Id_Rol == id);
    }
    public Rol? GetRolByName(string nombre)
    {
        return _db.rol.AsNoTracking().FirstOrDefault(r => r.Descripcion.ToLower() == nombre.ToLower());
    }
    public bool CreateRol(Rol rol)
    {
        rol.Fecha_Creacion = DateTime.Now;
        rol.Fecha_Modificacion = DateTime.Now;
        _db.rol.Add(rol);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateRol(Rol rol)
    {
        rol.Fecha_Modificacion = DateTime.Now;
        _db.rol.Update(rol);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteRolById(int id)
    {
        var rol = GetRolById(id);
        if (rol == null) return false;

        _db.rol.Remove(rol);
        return _db.SaveChanges() > 0;
    }
}
