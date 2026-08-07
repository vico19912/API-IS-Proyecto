using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateTipoEmpleadoDto
{
    [Required(ErrorMessage = "La descripción del tipo de empleado es requerida.")]
    [MinLength(5, ErrorMessage = "La descripción del tipo de empleado debe tener al menos 5 caracteres.")]
    public string Descripcion { get; set; }
}
