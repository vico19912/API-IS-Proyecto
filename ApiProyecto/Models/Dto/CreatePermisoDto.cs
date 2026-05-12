using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreatePermisoDto
{
    [Required(ErrorMessage = "La descripción del permiso es obligatoria.")]
    [StringLength(100, ErrorMessage = "La descripción del permiso no puede exceder los 100 caracteres.")]
    [MinLength(3, ErrorMessage = "El nombre del rol debe tener al menos 3 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;
    [Required(ErrorMessage = "El rol es obligatorio.")]
    public int Rol_Id { get; set; }
}
