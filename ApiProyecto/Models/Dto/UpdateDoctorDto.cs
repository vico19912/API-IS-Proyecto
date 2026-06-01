namespace ApiProyecto.Models.Dto;

public class UpdateDoctorDto
{
    public string Numero_Colegiatura { get; set; }
    public CreatePersonaDto Persona { get; set; }
    public EmpleadoDto Empleado { get; set; }
}
