using Microsoft.EntityFrameworkCore;
using ApiProyecto.Repository;
using ApiProyecto.Repository.IRepository;

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

app.Run();
