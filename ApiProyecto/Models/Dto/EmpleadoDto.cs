using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models.Dto;

public class EmpleadoDto
{
    public int Id_Empleado { get; set; }
    public string Password { get; set; }
    public int Hospital_Id { get; set; }
    public int Rol_Id { get; set; }
    public int Tipo_Empleado_Id { get; set; }
    public DateTime Fecha_Ingreso { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    public string Hospital_Nombre { get; set; }
    public string Rol_Nombre { get; set; }
    public string Tipo_Empleado_Nombre { get; set; }
}
