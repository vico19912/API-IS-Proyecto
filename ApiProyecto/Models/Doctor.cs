using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Doctor")]

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Doctor { get; set; }
    public string Numero_Colegiatura { get; set; } = string.Empty;
    public int Empleado_Id { get; set; }
    public int Persona_Id { get; set; }
    public int Especialidad_Id { get; set; }
    [ForeignKey("Persona_Id")]
    public Persona Persona { get; set; } = null!;
    [ForeignKey("Empleado_Id")]
    public Empleado Empleado { get; set; } = null!;
    [ForeignKey("Especialidad_Id")]
    public Especialidad Especialidad { get; set; } = null!;
}
