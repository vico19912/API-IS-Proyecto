using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Factura")]
public class Factura
{
    [Key]
    public int Id_Factura { get; set; }
    public int Cita_Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Monto { get; set; }
    [Required]
    public string Metodo_Pago { get; set; } = "Efectivo";
    [Required]
    public string Estado { get; set; } = "Pendiente";
    public DateTime Fecha_Creacion { get; set; } = DateTime.UtcNow;
    [ForeignKey("Cita_Id")]
    public Cita? Cita { get; set; }
}
