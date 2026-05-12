using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IPermisoRepository
{
    public ICollection<Permiso> GetAllPermisos();
    public Permiso? GetPermisoById(int id);
    public Permiso? GetPermisoByName(string nombre);
    public bool CreatePermiso(Permiso permiso);
    public bool UpdatePermiso(Permiso permiso);
    public bool DeletePermisoById(int id);
    public ICollection<Permiso> GetPermisoByRolId(int rolId);
}
