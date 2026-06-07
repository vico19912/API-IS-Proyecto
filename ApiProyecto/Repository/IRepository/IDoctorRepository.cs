using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IDoctorRepository
{
    public ICollection<Doctor> GetAllDoctors();
    public Doctor? GetDoctorById(int id);
    public bool CreateDoctor(Doctor doctor);
    public bool UpdateDoctor(Doctor doctor);
    public bool DeleteDoctor(int id);
    public Doctor? GetDoctorByName(string name);
}
