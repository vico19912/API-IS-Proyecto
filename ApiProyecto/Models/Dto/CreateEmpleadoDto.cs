using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateEmpleadoDto
{
    [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
    public string Password { get; set; }
    [Required(ErrorMessage = "El hospital es un campo obligatorio")]
    public int Hospital_Id { get; set; }
    [Required(ErrorMessage = "El rol es un campo obligatorio")]
    public int Rol_Id { get; set; }
    [Required(ErrorMessage = "El tipo de empleado es un campo obligatorio")]
    public int Tipo_Empleado_Id { get; set; }
}
