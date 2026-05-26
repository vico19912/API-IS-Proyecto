using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class HospitalRepository : IHospitalRepository
{
    private readonly ApplicationDbContext _db;
    public HospitalRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Hospital> GetAllHospitals()
    {
        return _db.hospital
                .OrderBy(h => h.Id_Hospital)
                .ToList();
    }
    public Hospital? GetHospitalById(int id)
    {
        return _db.hospital
              .FirstOrDefault(h => h.Id_Hospital == id);
    }
    public Hospital? GetHospitalByName(string name)
    {
        return _db.hospital
              .FirstOrDefault(h => h.Nombre == name);
    }
    public bool CreateHospital(Hospital hospital)
    {
        hospital.Fecha_Creacion = DateTime.UtcNow;
        hospital.Fecha_Modificacion = DateTime.UtcNow;
        _db.hospital.Add(hospital);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateHospital(Hospital hospital)
    {
        hospital.Fecha_Modificacion = DateTime.UtcNow;
        _db.hospital.Update(hospital);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteHospital(int id)
    {
        var hospital = GetHospitalById(id);
        if (hospital == null) return false;

        _db.hospital.Remove(hospital);
        return _db.SaveChanges() > 0;
    }
}
