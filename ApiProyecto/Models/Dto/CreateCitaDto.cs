using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateCitaDto
{
    [Required(ErrorMessage = "El ID del paciente es obligatorio")]
    public int Paciente_Id { get; set; }
    [Required(ErrorMessage = "El ID del doctor es obligatorio")]
    public int Doctor_Id { get; set; }
    [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
    public DateTime Fecha_Cita { get; set; }
}
