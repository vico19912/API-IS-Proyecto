using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateRolDto
{
    [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre del rol no puede exceder los 50 caracteres.")]
    [MinLength(3, ErrorMessage = "El nombre del rol debe tener al menos 3 caracteres.")]
    public string Descripcion { get; set; }
}
