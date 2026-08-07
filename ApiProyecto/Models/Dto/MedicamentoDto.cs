namespace ApiProyecto.Models.Dto;

public class MedicamentoDto
{
    public int Id_Medicamento { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Tipo_Medicamento_Id { get; set; }
    public string Tipo_Nombre { get; set; } = string.Empty;
}
