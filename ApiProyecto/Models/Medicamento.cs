using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyecto.Models;

[Table("Medicamento")]
public class Medicamento
{
    [Key]
    public int Id_Medicamento { get; set; }
    [Required]
    public string Descripcion { get; set; } = string.Empty;
    public int Tipo_Medicamento_Id { get; set; }
    [ForeignKey("Tipo_Medicamento_Id")]
    public TipoMedicamento? TipoMedicamento { get; set; }
}
