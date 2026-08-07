using Microsoft.EntityFrameworkCore;
using ApiProyecto.Repository;
using ApiProyecto.Repository.IRepository;
using ApiProyecto.Data;

var builder = WebApplication.CreateBuilder(args);

//Configuración del appsettings segun el entorno
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true,
        reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
var dbConnectionString =
    builder.Configuration.GetConnectionString("ConexionSql")
    ?? Environment.GetEnvironmentVariable("ConnectionStrings__ConexionSql");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        dbConnectionString,
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        }
    )
);

//Agregando el mapeo de los Dto's
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<ITipoEmpleadoRepository, TipoEmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
builder.Services.AddScoped<ITipoMedicamentoRepository, TipoMedicamentoRepository>();
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

//Instancia de AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Cargar datos de prueba con reintentos (SQL Server tarda en estar listo en Docker)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var intentos = 10;
    while (intentos-- > 0)
    {
        try
        {
            DataSeeder.Seed(db);
            Console.WriteLine("[Seeder] Datos cargados correctamente.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Seeder] No disponible, reintentando en 3s... ({ex.Message})");
            Thread.Sleep(3000);
        }
    }
}

app.Run();
