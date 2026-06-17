namespace ApiProyecto.Models.Dto;

public class PacienteDto
{
    public int Id_Paciente { get; set; }
    public CreatePersonaDto Persona { get; set; } = null!;
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
