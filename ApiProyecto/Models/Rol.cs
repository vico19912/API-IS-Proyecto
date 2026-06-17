using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Rol")]
public class Rol
{
    [Key]
    public int Id_Rol { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Estado { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}