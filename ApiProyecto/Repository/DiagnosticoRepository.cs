using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class DiagnosticoRepository : IDiagnosticoRepository
{
    private readonly ApplicationDbContext _db;
    public DiagnosticoRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public ICollection<Diagnostico> GetAllDiagnosticos()
    {
        return _db.diagnostico
            .Include(d => d.Cita)
                .ThenInclude(c => c.Paciente)
                    .ThenInclude(p => p.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Especialidad)
            .OrderByDescending(d => d.Fecha_Creacion)
            .AsNoTracking()
            .ToList();
    }
    public ICollection<Diagnostico> GetAllDiagnosticoByDNI(string dni)
    {
        return _db.diagnostico
            .Include(d => d.Cita)
                .ThenInclude(c => c.Paciente)
                    .ThenInclude(p => p.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Especialidad)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Empleado)
                        .ThenInclude(emp => emp.Hospital)
            .Where(d => d.Cita.Paciente.Persona.DNI == dni)
            .OrderByDescending(d => d.Fecha_Creacion)
            .AsNoTracking()
            .ToList();
    }
    public Diagnostico GetDiagnosticoById(int id)
    {
        return _db.diagnostico
            .Include(d => d.Cita)
                .ThenInclude(c => c.Paciente)
                    .ThenInclude(p => p.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Persona)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Especialidad)
            .Include(d => d.Cita)
                .ThenInclude(c => c.Doctor)
                    .ThenInclude(doc => doc.Empleado)
                        .ThenInclude(emp => emp.Hospital)
            .AsNoTracking()
            .FirstOrDefault(d => d.Id_Diagnostico == id);
    }
    public bool CreateDiagnostico(Diagnostico diagnostico)
    {
        diagnostico.Fecha_Creacion = DateTime.Now;
        diagnostico.Fecha_Modificacion = DateTime.Now;
        _db.diagnostico.Add(diagnostico);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateDiagnostico(Diagnostico diagnostico)
    {
        var diagnosticoUpdate = GetDiagnosticoById(diagnostico.Id_Diagnostico);
        if (diagnosticoUpdate == null) return false;

        diagnostico.Fecha_Modificacion = DateTime.Now;
        _db.diagnostico.Update(diagnostico);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteDiagnostico(int id)
    {
        var diagnostico = _db.diagnostico.Find(id);
        if (diagnostico != null)
        {
            _db.diagnostico.Remove(diagnostico);
            return _db.SaveChanges() > 0;
        }
        return false;
    }
}
