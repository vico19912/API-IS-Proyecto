using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateMedicamentoDto
{
    [Required(ErrorMessage = "La descripción es obligatoria")]
    [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
    public string Descripcion { get; set; } = string.Empty;
    [Required(ErrorMessage = "El tipo de medicamento es obligatorio")]
    public int Tipo_Medicamento_Id { get; set; }
}
