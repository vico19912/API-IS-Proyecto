using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    //Sets de la base de datos
    public DbSet<Rol> rol { get; set; }  
}