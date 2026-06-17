using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface ICitaRepository
{
    public ICollection<Cita> GetAllCitas();
    public ICollection<Cita> GetCitasByDoctorId(int doctorId);
    public Cita? GetCitaById(int id);
    public ICollection<Cita> GetCitasByPacienteId(int pacienteId);
    public bool CreateCita(Cita cita);
    public bool UpdateCita(Cita cita);
    public bool DeleteCita(int id);
}
