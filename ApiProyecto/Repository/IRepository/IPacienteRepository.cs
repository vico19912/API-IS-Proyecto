using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IPacienteRepository
{
    public ICollection<Paciente> GetAllPacientes();
    public Paciente? GetPacienteById(int id);
    public Paciente? GetPacienteByDNI(string dni);
    public bool CreatePaciente(Paciente paciente);
    public bool UpdatePaciente(Paciente paciente);
    public bool DeletePaciente(int id);

}
