using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Cita")]
public class Cita
{
    [Key]
    public int Id_Cita { get; set; }
    public int? Paciente_Id { get; set; }
    public int? Doctor_Id { get; set; }
    public DateTime Fecha_Cita { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    [ForeignKey("Paciente_Id")]
    public Paciente? Paciente { get; set; }
    [ForeignKey("Doctor_Id")]
    public Doctor? Doctor { get; set; }
}
