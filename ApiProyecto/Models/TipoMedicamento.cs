using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Tipo_Medicamento")]
public class TipoMedicamento
{
    [Key]
    public int Id_Tipo { get; set; }
    [Required]
    public string Descripcion { get; set; } = string.Empty;
}
