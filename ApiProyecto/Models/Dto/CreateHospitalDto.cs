using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateHospitalDto
{
    [Required(ErrorMessage = "El nombre del hospital es requerido.")]
    [MinLength(5, ErrorMessage = "El nombre del hospital debe tener al menos 5 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La dirección del hospital es requerida.")]
    [MinLength(5, ErrorMessage = "La dirección del hospital debe tener al menos 5 caracteres.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "El teléfono del hospital es requerido.")]
    public string Telefono { get; set; }
}
