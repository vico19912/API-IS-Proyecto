using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;
[Table("Permiso")]
public class Permiso
{
    [Key]
    public int Id_Permiso { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Rol_Id { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
