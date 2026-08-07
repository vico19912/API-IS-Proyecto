using ApiProyecto.Models.Dto;

namespace ApiProyecto.Models.Dto;

public class DoctorDto
{
    public int Id_Doctor { get; set; }
    public string Numero_Colegiatura { get; set; }
    public CreatePersonaDto Persona { get; set; }
    public EmpleadoDto Empleado { get; set; }
    public EspecialidadDto Especialidad { get; set; }
}
