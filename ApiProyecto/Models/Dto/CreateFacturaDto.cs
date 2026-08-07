using System.ComponentModel.DataAnnotations;

namespace ApiProyecto.Models.Dto;

public class CreateFacturaDto
{
    [Required(ErrorMessage = "La cita es obligatoria")]
    public int Cita_Id { get; set; }
    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }
    [Required(ErrorMessage = "El método de pago es obligatorio")]
    public string Metodo_Pago { get; set; } = "Efectivo";
    public string Estado { get; set; } = "Pendiente";
}
