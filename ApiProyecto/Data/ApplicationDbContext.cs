using Microsoft.EntityFrameworkCore;
using ApiProyecto.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    //Sets de la base de datos
    public DbSet<Rol> rol { get; set; }
    public DbSet<Permiso> permiso { get; set; }
    public DbSet<Paciente> paciente { get; set; }
    public DbSet<Persona> persona { get; set; }
    public DbSet<Doctor> doctor { get; set; }
    public DbSet<Empleado> empleado { get; set; }
    public DbSet<Especialidad> especialidad { get; set; }
    public DbSet<Hospital> hospital { get; set; }
    public DbSet<TipoEmpleado> tipoempleado { get; set; }
    public DbSet<Cita> cita { get; set; }
    public DbSet<Diagnostico> diagnostico { get; set; }
}
