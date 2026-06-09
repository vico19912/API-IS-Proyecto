namespace ApiProyecto.Models.Dto;

public class CitaDto
{
    public int Id_Cita { get; set; }
    public PacienteDto Paciente { get; set; }
    public DoctorDto Doctor { get; set; }
    public DateTime Fecha_Cita { get; set; }
}
