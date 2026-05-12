namespace ApiProyecto.Models.Dto;
public class RolDto
{
    public int Id_Rol { get; set; }
    public string Descripcion { get; set; }
    public int Estado { get; set; } = 1;
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
