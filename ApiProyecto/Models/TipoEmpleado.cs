using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Tipo_Empleado")]
public class TipoEmpleado
{
    [Key]
    public int Id_Tipo_Empleado { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
