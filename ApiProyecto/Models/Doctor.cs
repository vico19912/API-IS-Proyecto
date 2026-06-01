using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Doctor")]

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Doctor { get; set; }
    public string Numero_Colegiatura { get; set; }
    public int Empleado_Id { get; set; }
    public int Persona_Id { get; set; }
    public int Especialidad_Id { get; set; }
    [ForeignKey("Persona_Id")]
    public Persona Persona { get; set; }
    [ForeignKey("Empleado_Id")]
    public Empleado Empleado { get; set; }
    [ForeignKey("Especialidad_Id")]
    public Especialidad Especialidad { get; set; }
}
