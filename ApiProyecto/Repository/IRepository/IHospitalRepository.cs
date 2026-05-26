using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IHospitalRepository
{
    public ICollection<Hospital> GetAllHospitals();
    public Hospital? GetHospitalById(int id);
    public Hospital? GetHospitalByName(string name);
    public bool CreateHospital(Hospital hospital);
    public bool UpdateHospital(Hospital hospital);
    public bool DeleteHospital(int id);
}
