using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateEspecialidadDto
{
    [Required(ErrorMessage = "La descripción de la especialidad es requerida.")]
    [MinLength(5, ErrorMessage = "La descripción de la especialidad debe tener al menos 5 caracteres.")]
    public string Descripcion { get; set; }
}
