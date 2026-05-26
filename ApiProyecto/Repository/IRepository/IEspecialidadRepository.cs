using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IEspecialidadRepository
{
    public ICollection<Especialidad> GetAllEspecialidades();
    public Especialidad? GetEspecialidadById(int id);
    public Especialidad? GetEspecialidadByName(string name);
    public bool CreateEspecialidad(Especialidad especialidad);
    public bool UpdateEspecialidad(Especialidad especialidad);
    public bool DeleteEspecialidad(int id);
}
