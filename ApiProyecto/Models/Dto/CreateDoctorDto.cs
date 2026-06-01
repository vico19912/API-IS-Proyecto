using System.ComponentModel.DataAnnotations;
using ApiProyecto.Models.Dto;

namespace ApiProyecto.Models.Dto;

public class CreateDoctorDto
{
    [Required(ErrorMessage = "El número de colegiatura es obligatorio")]
    [MinLength(5, ErrorMessage = "El número de colegiatura debe tener al menos 5 caracteres")]
    public string Numero_Colegiatura { get; set; }

    [Required(ErrorMessage = "El ID del empleado es obligatorio")]
    public CreateEmpleadoDto empleado { get; set; }

    [Required(ErrorMessage = "El ID de la especialidad es obligatorio")]
    public int Especialidad_Id { get; set; }

    [Required(ErrorMessage = "Los datos de la persona son obligatorios")]
    public CreatePersonaDto Persona { get; set; }
}
