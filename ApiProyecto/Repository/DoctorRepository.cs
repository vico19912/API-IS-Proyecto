using ApiProyecto.Models;
using ApiProyecto.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Repository;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _db;
    public DoctorRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public ICollection<Doctor> GetAllDoctors()
    {
        return _db.doctor
                .Include(d => d.Persona)
                .Include(d => d.Empleado)
                .Include(d => d.Especialidad)
                .Include(d => d.Empleado.Hospital)
                .Include(d => d.Empleado.Rol)
                .Include(d => d.Empleado.TipoEmpleado)
                .OrderBy(d => d.Id_Doctor)
                .AsNoTracking()
                .ToList();
    }
    public Doctor? GetDoctorById(int id)
    {
        return _db.doctor
              .Include(d => d.Persona)
              .Include(d => d.Empleado)
              .Include(d => d.Especialidad)
              .FirstOrDefault(d => d.Id_Doctor == id);
    }
    public bool CreateDoctor(Doctor doctor)
    {
        _db.persona.Add(doctor.Persona);
        _db.SaveChanges();

        doctor.Persona_Id = doctor.Persona.Id_Persona;
        doctor.Empleado.Fecha_Ingreso = DateTime.UtcNow;
        doctor.Empleado.Fecha_Modificacion = DateTime.UtcNow;
        _db.doctor.Add(doctor);
        return _db.SaveChanges() > 0;
    }
    public bool UpdateDoctor(Doctor doctor)
    {
        var personaRows = _db.persona
        .Where(p => p.Id_Persona == doctor.Persona_Id)
        .ExecuteUpdate(s => s
            .SetProperty(p => p.DNI, doctor.Persona.DNI)
            .SetProperty(p => p.Nombre, doctor.Persona.Nombre)
            .SetProperty(p => p.Nombre_2, doctor.Persona.Nombre_2)
            .SetProperty(p => p.Apellido, doctor.Persona.Apellido)
            .SetProperty(p => p.Apellido_2, doctor.Persona.Apellido_2)
            .SetProperty(p => p.Telefono, doctor.Persona.Telefono)
            .SetProperty(p => p.Correo, doctor.Persona.Correo)
            .SetProperty(p => p.Sexo, doctor.Persona.Sexo)
            .SetProperty(p => p.Fecha_Nacimiento, doctor.Persona.Fecha_Nacimiento)
        );

        var empleadoRows = _db.empleado
            .Where(e => e.Id_Empleado == doctor.Empleado_Id)
            .ExecuteUpdate(s => s
                .SetProperty(e => e.Password, doctor.Empleado.Password)
                .SetProperty(e => e.Hospital_Id, doctor.Empleado.Hospital_Id)
                .SetProperty(e => e.Rol_Id, doctor.Empleado.Rol_Id)
                .SetProperty(e => e.Tipo_Empleado_Id, doctor.Empleado.Tipo_Empleado_Id)
                .SetProperty(e => e.Fecha_Ingreso, doctor.Empleado.Fecha_Ingreso)
                .SetProperty(e => e.Fecha_Modificacion, DateTime.UtcNow)
            );

        var doctorRows = _db.doctor
            .Where(d => d.Id_Doctor == doctor.Id_Doctor)
            .ExecuteUpdate(s => s
                .SetProperty(d => d.Numero_Colegiatura, doctor.Numero_Colegiatura)
                .SetProperty(d => d.Especialidad_Id, doctor.Especialidad_Id)
            );

        return personaRows > 0 && empleadoRows > 0 && doctorRows > 0;
    }
    public bool DeleteDoctor(int id)
    {
        var doctor = GetDoctorById(id);
        if (doctor == null) return false;

        _db.doctor.Remove(doctor);
        return _db.SaveChanges() > 0;
    }
}
