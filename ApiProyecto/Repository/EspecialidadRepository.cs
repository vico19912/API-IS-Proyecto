using ApiProyecto.Repository.IRepository;
using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class EspecialidadRepository : IEspecialidadRepository
{
    private readonly ApplicationDbContext _db;

    public EspecialidadRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Especialidad> GetAllEspecialidades()
    {
        return _db.especialidad
                .OrderBy(e => e.Id_Especialidad)
                .ToList();
    }
    public Especialidad? GetEspecialidadById(int id)
    {
        return _db.especialidad
              .FirstOrDefault(e => e.Id_Especialidad == id);
    }
    public Especialidad? GetEspecialidadByName(string name)
    {
        return _db.especialidad
              .FirstOrDefault(e => e.Descripcion.ToLower() == name.ToLower());
    }
    public bool CreateEspecialidad(Especialidad especialidad)
    {
        especialidad.Fecha_Creacion = DateTime.UtcNow;
        especialidad.Fecha_Modificacion = DateTime.UtcNow;
        _db.especialidad.Add(especialidad);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateEspecialidad(Especialidad especialidad)
    {
        especialidad.Fecha_Modificacion = DateTime.UtcNow;
        _db.especialidad.Update(especialidad);
        return _db.SaveChanges() > 0;
    }
    public bool DeleteEspecialidad(int id)
    {
        var especialidad = GetEspecialidadById(id);
        if (especialidad == null) return false;

        _db.especialidad.Remove(especialidad);
        return _db.SaveChanges() > 0;
    }
}
