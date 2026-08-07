using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateTipoMedicamentoDto
{
    [Required(ErrorMessage = "La descripción es obligatoria")]
    [MinLength(3, ErrorMessage = "La descripción debe tener al menos 3 caracteres")]
    public string Descripcion { get; set; } = string.Empty;
}
