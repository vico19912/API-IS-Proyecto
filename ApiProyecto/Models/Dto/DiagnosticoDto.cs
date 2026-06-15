using System.Text.Json.Serialization;

namespace ApiProyecto.Models.Dto;

public class DiagnosticoDto
{
    public int Id_Diagnostico { get; set; }
    public string Descripcion { get; set; }
    public string Comentario { get; set; }
    public CitaDto Cita { get; set; }
}
