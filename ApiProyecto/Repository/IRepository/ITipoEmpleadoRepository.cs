using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface ITipoEmpleadoRepository
{
    public ICollection<TipoEmpleado> GetAllTipoEmpleados();
    public TipoEmpleado? GetTipoEmpleadoById(int id);
    public TipoEmpleado? GetTipoEmpleadoByDescripcion(string descripcion);
    public bool CreateTipoEmpleado(TipoEmpleado tipoEmpleado);
    public bool UpdateTipoEmpleado(TipoEmpleado tipoEmpleado);
    public bool DeleteTipoEmpleadoById(int id);
}
