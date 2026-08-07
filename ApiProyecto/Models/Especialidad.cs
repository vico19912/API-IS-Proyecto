using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Especialidad")]
public class Especialidad
{
    [Key]
    public int Id_Especialidad { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
