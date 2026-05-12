namespace ApiProyecto.Models.Dto;

public class PermisoDto
{
    public int Id_Permiso { get; set; }
    public string Descripcion { get; set; }
    public int Rol_Id { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
}
