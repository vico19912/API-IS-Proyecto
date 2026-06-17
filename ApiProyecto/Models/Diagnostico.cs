using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiProyecto.Models;

[Table("Diagnostico")]
public class Diagnostico
{
    [Key]
    public int Id_Diagnostico { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    public int Cita_Id { get; set; }
    [ForeignKey("Cita_Id")]
    public Cita Cita { get; set; } = null!;
}
