using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreatePacienteDto
{
    [Required(ErrorMessage = "El DNI es un campo obligatorio")]
    [MinLength(5, ErrorMessage = "El DNI debe contener como minimo 5 caracteres")]
    public string DNI { get; set; }
    [Required(ErrorMessage = "El primer nombre es obligarorio")]
    [MinLength(3, ErrorMessage = "El nombre debe contener por lo menos 3 caracteres")]
    public string Nombre { get; set; }
    public string Nombre_2 { get; set; }
    [Required(ErrorMessage = "El primer apellido es obligatorio")]
    [MinLength(3, ErrorMessage = "El apellido debe contener por lo menos 3 caracteres")]
    public string Apellido { get; set; }
    public string Apellido_2 { get; set; }
    public string Telefono { get; set; }
    [EmailAddress(ErrorMessage = "El correo no tiene un formato valido")]
    public string Correo { get; set; }
    public char Sexo { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
}
