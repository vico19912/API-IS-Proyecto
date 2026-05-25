using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Paciente")]
public class Paciente
{
    [Key]
    public int Id_Paciente { get; set; }
    public int Persona_Id { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }

    [ForeignKey("Persona_Id")]
    public Persona Persona { get; set; }
}
