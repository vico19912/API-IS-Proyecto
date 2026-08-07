namespace ApiProyecto.Models.Dto;

public class FacturaDto
{
    public int Id_Factura { get; set; }
    public int Cita_Id { get; set; }
    public decimal Monto { get; set; }
    public string Metodo_Pago { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public DateTime Fecha_Creacion { get; set; }
    public CitaDto? Cita { get; set; }
}
