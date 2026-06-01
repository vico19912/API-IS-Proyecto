using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IEmpleadoRepository
{
    public ICollection<Empleado> GetAllEmpleados();
    public ICollection<Empleado> GetEmpleadoByHospitalId(int hospitalId);
    public Empleado? GetEmpleadoById(int id);
    public bool CreateEmpleado(Empleado empleado);
    public bool UpdateEmpleado(Empleado empleado);
    public bool DeleteEmpleado(int id);
}
