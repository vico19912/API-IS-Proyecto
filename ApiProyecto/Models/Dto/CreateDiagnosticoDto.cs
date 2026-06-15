using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateDiagnosticoDto
{
    [Required(ErrorMessage = "La descripción del diagnóstico es obligatoria.")]
    [MinLength(5, ErrorMessage = "La descripción del diagnóstico debe tener al menos 5 caracteres.")]
    public string Descripcion { get; set; }
    public string Comentario { get; set; }
    [Required(ErrorMessage = "El ID de la cita es obligatorio.")]
    public int Cita_Id { get; set; }
}
