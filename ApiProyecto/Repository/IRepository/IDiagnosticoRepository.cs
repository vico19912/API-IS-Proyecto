using ApiProyecto.Models;

namespace ApiProyecto.Repository.IRepository;

public interface IDiagnosticoRepository
{
    public ICollection<Diagnostico> GetAllDiagnosticoByDNI(string dni);
    public Diagnostico GetDiagnosticoById(int id);
    public bool CreateDiagnostico(Diagnostico diagnostico);
    public bool UpdateDiagnostico(Diagnostico diagnostico);
    public bool DeleteDiagnostico(int id);
}
