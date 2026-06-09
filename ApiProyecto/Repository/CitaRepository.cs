using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class CitaRepository : ICitaRepository
{
    private readonly ApplicationDbContext _db;

    public CitaRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Cita> GetAllCitas()
    {
        return _db.cita
        .Include(c => c.Paciente)
            .ThenInclude(p => p.Persona)
        .Include(c => c.Doctor)
            .ThenInclude(d => d.Persona)
        .Include(c => c.Doctor)
            .ThenInclude(d => d.Especialidad)
        .Include(c => c.Doctor)
            .ThenInclude(d => d.Empleado)
                .ThenInclude(e => e.Hospital)
        .OrderBy(c => c.Id_Cita)
        .AsNoTracking()
        .ToList();
    }
    public Cita? GetCitaById(int id)
    {
        return _db.cita
                .Include(c => c.Paciente)
                .Include(c => c.Paciente.Persona)
                .Include(c => c.Doctor)
                .Include(c => c.Doctor.Persona)
                .Include(c => c.Doctor.Especialidad)
                .Include(c => c.Doctor.Empleado.Hospital)
                .FirstOrDefault(c => c.Id_Cita == id);
    }
    public Cita? GetCitaByPacienteId(int pacienteId)
    {
        return _db.cita
                .Include(c => c.Paciente)
                .Include(c => c.Paciente.Persona)
                .Include(c => c.Doctor)
                .Include(c => c.Doctor.Persona)
                .Include(c => c.Doctor.Especialidad)
                .Include(c => c.Doctor.Empleado.Hospital)
                .FirstOrDefault(c => c.Paciente_Id == pacienteId);
    }
    public ICollection<Cita> GetCitasByDoctorId(int doctorId)
    {
        return _db.cita
                .Include(c => c.Paciente)
                .Include(c => c.Paciente.Persona)
                .Include(c => c.Doctor)
                .Include(c => c.Doctor.Persona)
                .Include(c => c.Doctor.Especialidad)
                .Include(c => c.Doctor.Empleado.Hospital)
                .Where(c => c.Doctor_Id == doctorId).ToList();
    }
    public bool CreateCita(Cita cita)
    {
        cita.Fecha_Modificacion = DateTime.UtcNow;
        _db.cita.Add(cita);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateCita(Cita cita)
    {
        var citaToUpdate = _db.cita.FirstOrDefault(c => c.Id_Cita == cita.Id_Cita);
        if (citaToUpdate == null) return false;

        citaToUpdate.Paciente_Id = cita.Paciente_Id;
        citaToUpdate.Doctor_Id = cita.Doctor_Id;
        citaToUpdate.Fecha_Modificacion = DateTime.UtcNow;

        _db.cita.Update(citaToUpdate);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteCita(int id)
    {
        var cita = GetCitaById(id);
        if (cita == null) return false;

        _db.cita.Remove(cita);
        return _db.SaveChanges() > 0;
    }
}
