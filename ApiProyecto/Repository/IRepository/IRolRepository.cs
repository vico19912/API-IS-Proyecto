namespace ApiProyecto.Repository.IRepository;

public interface IRolRepository
{
    ICollection<Rol> GetAllRoles();
    Rol? GetRolById(int id);
    Rol? GetRolByName(string nombre);
    bool CreateRol(Rol rol);
    bool UpdateRol(Rol rol);
    bool DeleteRolById(int id);
}
