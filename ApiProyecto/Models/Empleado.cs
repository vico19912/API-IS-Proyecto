using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiProyecto.Models;

namespace ApiProyecto.Models;

[Table("Empleado")]
public class Empleado
{
    [Key]
    public int Id_Empleado { get; set; }
    public string Password { get; set; }
    public int Hospital_Id { get; set; }
    public int Rol_Id { get; set; }
    public int Tipo_Empleado_Id { get; set; }
    public DateTime Fecha_Ingreso { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    [ForeignKey("Hospital_Id")]
    public Hospital Hospital { get; set; }
    [ForeignKey("Rol_Id")]
    public Rol Rol { get; set; }
    [ForeignKey("Tipo_Empleado_Id")]
    public TipoEmpleado TipoEmpleado { get; set; }
}
