using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreatePersonaDto
{
    [Required(ErrorMessage = "El DNI es obligatorio")]
    [MinLength(5, ErrorMessage = "El DNI debe tener al menos 5 caracteres")]
    public string DNI { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
    public string Nombre { get; set; }
    public string Nombre_2 { get; set; }
    [Required(ErrorMessage = "El apellido es obligatorio")]
    [MinLength(2, ErrorMessage = "El apellido debe tener al menos 2 caracteres")]
    public string Apellido { get; set; }
    public string Apellido_2 { get; set; }
    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [MinLength(5, ErrorMessage = "El teléfono debe tener al menos 5 caracteres")]
    public string Telefono { get; set; }
    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Correo { get; set; }
    [Required(ErrorMessage = "El sexo es obligatorio")]
    public char Sexo { get; set; }
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime Fecha_Nacimiento { get; set; }
}
