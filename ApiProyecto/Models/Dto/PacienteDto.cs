namespace ApiProyecto.Models.Dto;

public class PacienteDto
{
    public int Id_Paciente { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Nombre_2 { get; set; }
    public string Apellido { get; set; }
    public string Apellido_2 { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public char Sexo { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
}
