using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly ApplicationDbContext _db;

    public PacienteRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool CreatePaciente(Paciente paciente)
    {

        _db.persona.Add(paciente.Persona);
        _db.SaveChanges();

        paciente.Persona_Id = paciente.Persona.Id_Persona;
        paciente.Fecha_Creacion = DateTime.UtcNow;
        paciente.Fecha_Modificacion = DateTime.UtcNow;
        _db.paciente.Add(paciente);
        return _db.SaveChanges() > 0;
    }


    public ICollection<Paciente> GetAllPacientes()
    {
        return _db.paciente
                .Include(p => p.Persona)
                .OrderBy(p => p.Id_Paciente)
                .ToList();
    }
    public Paciente? GetPacienteByDNI(string dni)
    {
        return _db.paciente
              .Include(p => p.Persona)
              .FirstOrDefault(p => p.Persona.DNI == dni);
    }

    public Paciente? GetPacienteById(int id)
    {
        return _db.paciente
              .Include(p => p.Persona)
              .FirstOrDefault(p => p.Persona.Id_Persona == id);
    }

    public bool UpdatePaciente(Paciente paciente)
    {
        paciente.Fecha_Modificacion = DateTime.UtcNow;
        _db.persona.Update(paciente.Persona);
        _db.paciente.Update(paciente);
        return _db.SaveChanges() > 0;
    }
    public bool DeletePaciente(int id)
    {
        var paciente = GetPacienteById(id);
        if (paciente == null) return false;

        _db.paciente.Remove(paciente);
        return _db.SaveChanges() > 0;
    }
}
