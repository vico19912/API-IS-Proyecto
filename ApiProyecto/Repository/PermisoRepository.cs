using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class PermisoRepository : IPermisoRepository
{
    private readonly ApplicationDbContext _db;

    public PermisoRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public ICollection<Permiso> GetAllPermisos()
    {
        return _db.permiso.OrderBy(p => p.Id_Permiso).ToList();
    }
    public Permiso? GetPermisoById(int id)
    {
        return _db.permiso.AsNoTracking().FirstOrDefault(p => p.Id_Permiso == id);
    }
    public Permiso? GetPermisoByName(string nombre)
    {
        return _db.permiso.AsNoTracking().FirstOrDefault(p => p.Descripcion.ToLower() == nombre.ToLower());
    }
    public bool CreatePermiso(Permiso permiso)
    {
        permiso.Fecha_Creacion = DateTime.Now;
        permiso.Fecha_Modificacion = DateTime.Now;
        _db.permiso.Add(permiso);
        return _db.SaveChanges() > 0;
    }
    public bool UpdatePermiso(Permiso permiso)
    {
        permiso.Fecha_Modificacion = DateTime.Now;
        _db.permiso.Update(permiso);
        return _db.SaveChanges() > 0;
    }
    public bool DeletePermisoById(int id)
    {
        var permiso = GetPermisoById(id);
        if (permiso == null) return false;

        _db.permiso.Remove(permiso);
        return _db.SaveChanges() > 0;
    }
    public ICollection<Permiso> GetPermisoByRolId(int rolId)
    {
        return _db.permiso.Where(p => p.Rol_Id == rolId).OrderBy(p => p.Id_Permiso).ToList();
    }
}
