using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;
[Table("Persona")]

public class Persona
{
    [Key]
    public int Id_Persona { get; set; }
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Nombre_2 { get; set; }
    public string Apellido { get; set; } = string.Empty;
    public string? Apellido_2 { get; set; }
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public char Sexo { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
}
