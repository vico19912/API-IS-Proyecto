using ApiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProyecto.Data;

public static class DataSeeder
{
    public static void Seed(ApplicationDbContext db)
    {
        db.Database.EnsureCreated();
        SeedRoles(db);
        SeedPermisos(db);
        SeedTiposEmpleado(db);
        SeedHospitales(db);
        SeedEspecialidades(db);
        SeedTiposMedicamento(db);
        SeedMedicamentos(db);
        SeedPersonasYEmpleadosYDoctores(db);
        SeedPacientes(db);
        SeedCitas(db);
        SeedDiagnosticos(db);
        SeedFacturas(db);
    }

    static void SeedRoles(ApplicationDbContext db)
    {
        if (db.rol.Any()) return;
        db.rol.AddRange(
            new Rol { Descripcion = "Administrador",   Estado = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Rol { Descripcion = "Doctor",          Estado = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Rol { Descripcion = "Recepcionista",   Estado = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Rol { Descripcion = "Enfermería",      Estado = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) }
        );
        db.SaveChanges();
    }

    static void SeedPermisos(ApplicationDbContext db)
    {
        if (db.permiso.Any()) return;
        // Roles: 1=Admin, 2=Doctor, 3=Recepcionista, 4=Enfermería
        db.permiso.AddRange(
            new Permiso { Descripcion = "Gestionar usuarios",       Rol_Id = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Ver reportes completos",   Rol_Id = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Configurar sistema",       Rol_Id = 1, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Registrar diagnósticos",   Rol_Id = 2, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Generar recetas",          Rol_Id = 2, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Ver historial pacientes",  Rol_Id = 2, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Gestionar citas",          Rol_Id = 3, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Registrar pacientes",      Rol_Id = 3, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Facturación",              Rol_Id = 3, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Permiso { Descripcion = "Registrar signos vitales", Rol_Id = 4, Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) }
        );
        db.SaveChanges();
    }

    static void SeedTiposEmpleado(ApplicationDbContext db)
    {
        if (db.tipoempleado.Any()) return;
        db.tipoempleado.AddRange(
            new TipoEmpleado { Descripcion = "Médico Especialista",    Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new TipoEmpleado { Descripcion = "Médico General",         Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new TipoEmpleado { Descripcion = "Personal Administrativo",Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new TipoEmpleado { Descripcion = "Enfermería",             Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) }
        );
        db.SaveChanges();
    }

    static void SeedHospitales(ApplicationDbContext db)
    {
        if (db.hospital.Any()) return;
        db.hospital.AddRange(
            new Hospital { Nombre = "Hospital Escuela Universitario",     Direccion = "Blvd. Suyapa, Tegucigalpa",   Telefono = "22326217", Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Hospital { Nombre = "Hospital San Felipe",                Direccion = "Col. Alameda, Tegucigalpa",   Telefono = "22316218", Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Hospital { Nombre = "Clínica Médica CEUTEC",             Direccion = "Ring Periférico, Tegucigalpa", Telefono = "22891111", Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) }
        );
        db.SaveChanges();
    }

    static void SeedEspecialidades(ApplicationDbContext db)
    {
        if (db.especialidad.Any()) return;
        db.especialidad.AddRange(
            new Especialidad { Descripcion = "Medicina General",   Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Cardiología",        Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Pediatría",          Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Ginecología",        Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Neurología",         Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Traumatología",      Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) },
            new Especialidad { Descripcion = "Dermatología",       Fecha_Creacion = D(2024,1,10), Fecha_Modificacion = D(2024,1,10) }
        );
        db.SaveChanges();
    }

    static void SeedTiposMedicamento(ApplicationDbContext db)
    {
        if (db.tipoMedicamento.Any()) return;
        db.tipoMedicamento.AddRange(
            new TipoMedicamento { Descripcion = "Analgésico"       },
            new TipoMedicamento { Descripcion = "Antibiótico"      },
            new TipoMedicamento { Descripcion = "Antiinflamatorio" },
            new TipoMedicamento { Descripcion = "Antihipertensivo" },
            new TipoMedicamento { Descripcion = "Vitaminas"        },
            new TipoMedicamento { Descripcion = "Antiácido"        }
        );
        db.SaveChanges();
    }

    static void SeedMedicamentos(ApplicationDbContext db)
    {
        if (db.medicamento.Any()) return;
        // TipoMedicamento IDs: 1=Analgésico, 2=Antibiótico, 3=Antiinflamatorio, 4=Antihipertensivo, 5=Vitaminas, 6=Antiácido
        db.medicamento.AddRange(
            new Medicamento { Descripcion = "Paracetamol 500mg",         Tipo_Medicamento_Id = 1 },
            new Medicamento { Descripcion = "Ibuprofeno 400mg",          Tipo_Medicamento_Id = 3 },
            new Medicamento { Descripcion = "Amoxicilina 500mg",         Tipo_Medicamento_Id = 2 },
            new Medicamento { Descripcion = "Azitromicina 500mg",        Tipo_Medicamento_Id = 2 },
            new Medicamento { Descripcion = "Enalapril 10mg",            Tipo_Medicamento_Id = 4 },
            new Medicamento { Descripcion = "Losartán 50mg",             Tipo_Medicamento_Id = 4 },
            new Medicamento { Descripcion = "Vitamina C 1000mg",         Tipo_Medicamento_Id = 5 },
            new Medicamento { Descripcion = "Complejo B",                Tipo_Medicamento_Id = 5 },
            new Medicamento { Descripcion = "Omeprazol 20mg",            Tipo_Medicamento_Id = 6 },
            new Medicamento { Descripcion = "Diclofenac sódico 50mg",    Tipo_Medicamento_Id = 3 }
        );
        db.SaveChanges();
    }

    static void SeedPersonasYEmpleadosYDoctores(ApplicationDbContext db)
    {
        if (db.doctor.Any()) return;

        // Personas para doctores
        var personas = new List<Persona>
        {
            new Persona { DNI="0801198012345", Nombre="Carlos",    Nombre_2="Andrés",  Apellido="Mendoza",  Apellido_2="Reyes",   Telefono="95551001", Correo="carlos.mendoza@hospitale.hn",   Sexo='M', Fecha_Nacimiento=D(1980,3,15) },
            new Persona { DNI="0801197523678", Nombre="María",     Nombre_2="José",    Apellido="Rodríguez",Apellido_2="Fuentes", Telefono="95551002", Correo="maria.rodriguez@hospitale.hn",  Sexo='F', Fecha_Nacimiento=D(1975,7,22) },
            new Persona { DNI="0801198534891", Nombre="Jorge",     Nombre_2="Luis",    Apellido="Hernández",Apellido_2="López",   Telefono="95551003", Correo="jorge.hernandez@hospitale.hn",  Sexo='M', Fecha_Nacimiento=D(1985,11,8) },
            new Persona { DNI="0801199012456", Nombre="Ana",       Nombre_2="Patricia",Apellido="García",   Apellido_2="Sosa",    Telefono="95551004", Correo="ana.garcia@hospitale.hn",       Sexo='F', Fecha_Nacimiento=D(1990,5,30) },
        };
        db.persona.AddRange(personas);
        db.SaveChanges();

        // Empleados (Hospital IDs: 1,2,3 — Rol 2=Doctor — TipoEmpleado 1=Especialista, 2=General)
        var empleados = new List<Empleado>
        {
            new Empleado { Password="Doc@2024!",   Hospital_Id=1, Rol_Id=2, Tipo_Empleado_Id=1, Fecha_Ingreso=D(2015,3,1),  Fecha_Modificacion=D(2024,1,10) },
            new Empleado { Password="Doc@2024!",   Hospital_Id=1, Rol_Id=2, Tipo_Empleado_Id=1, Fecha_Ingreso=D(2012,8,15), Fecha_Modificacion=D(2024,1,10) },
            new Empleado { Password="Doc@2024!",   Hospital_Id=2, Rol_Id=2, Tipo_Empleado_Id=2, Fecha_Ingreso=D(2018,1,20), Fecha_Modificacion=D(2024,1,10) },
            new Empleado { Password="Doc@2024!",   Hospital_Id=3, Rol_Id=2, Tipo_Empleado_Id=1, Fecha_Ingreso=D(2020,6,5),  Fecha_Modificacion=D(2024,1,10) },
        };
        db.empleado.AddRange(empleados);
        db.SaveChanges();

        // Doctores (Especialidades: 1=Med.Gral, 2=Cardio, 3=Pediatría, 4=Gineco, 5=Neuro, 6=Trauma, 7=Derma)
        db.doctor.AddRange(
            new Doctor { Numero_Colegiatura="COL-10245", Empleado_Id=empleados[0].Id_Empleado, Persona_Id=personas[0].Id_Persona, Especialidad_Id=2 },
            new Doctor { Numero_Colegiatura="COL-10389", Empleado_Id=empleados[1].Id_Empleado, Persona_Id=personas[1].Id_Persona, Especialidad_Id=4 },
            new Doctor { Numero_Colegiatura="COL-10512", Empleado_Id=empleados[2].Id_Empleado, Persona_Id=personas[2].Id_Persona, Especialidad_Id=1 },
            new Doctor { Numero_Colegiatura="COL-10678", Empleado_Id=empleados[3].Id_Empleado, Persona_Id=personas[3].Id_Persona, Especialidad_Id=3 }
        );
        db.SaveChanges();
    }

    static void SeedPacientes(ApplicationDbContext db)
    {
        if (db.paciente.Any()) return;

        var personas = new List<Persona>
        {
            new Persona { DNI="0801199534217", Nombre="Luis",      Nombre_2="Fernando",Apellido="Torres",   Apellido_2="Mejía",   Telefono="99881001", Correo="luis.torres@gmail.com",    Sexo='M', Fecha_Nacimiento=D(1995,2,14) },
            new Persona { DNI="0801200112378", Nombre="Sofía",     Nombre_2="",        Apellido="Martínez", Apellido_2="Cruz",    Telefono="99881002", Correo="sofia.martinez@gmail.com",  Sexo='F', Fecha_Nacimiento=D(2001,9,3)  },
            new Persona { DNI="0801198745632", Nombre="Roberto",   Nombre_2="Ernesto", Apellido="Álvarez",  Apellido_2="Pineda",  Telefono="99881003", Correo="roberto.alvarez@gmail.com", Sexo='M', Fecha_Nacimiento=D(1987,6,20) },
            new Persona { DNI="0801200345891", Nombre="Valentina", Nombre_2="",        Apellido="Flores",   Apellido_2="Sánchez", Telefono="99881004", Correo="valentina.flores@gmail.com",Sexo='F', Fecha_Nacimiento=D(2003,12,7) },
            new Persona { DNI="0801197212456", Nombre="Manuel",    Nombre_2="Antonio", Apellido="Castillo", Apellido_2="Reina",   Telefono="99881005", Correo="manuel.castillo@gmail.com", Sexo='M', Fecha_Nacimiento=D(1972,4,25) },
            new Persona { DNI="0801199823145", Nombre="Karla",     Nombre_2="Beatriz", Apellido="Domínguez",Apellido_2="Vega",    Telefono="99881006", Correo="karla.dominguez@gmail.com", Sexo='F', Fecha_Nacimiento=D(1998,8,11) },
            new Persona { DNI="0801196512789", Nombre="Héctor",    Nombre_2="",        Apellido="Fuentes",  Apellido_2="Morales", Telefono="99881007", Correo="hector.fuentes@gmail.com",  Sexo='M', Fecha_Nacimiento=D(1965,1,30) },
            new Persona { DNI="0801200678234", Nombre="Isabella",  Nombre_2="",        Apellido="Ramos",    Apellido_2="Díaz",    Telefono="99881008", Correo="isabella.ramos@gmail.com",  Sexo='F', Fecha_Nacimiento=D(2006,10,18)},
        };
        db.persona.AddRange(personas);
        db.SaveChanges();

        db.paciente.AddRange(personas.Select(p => new Paciente
        {
            Persona_Id = p.Id_Persona,
            Fecha_Creacion = D(2024, 2, 1),
            Fecha_Modificacion = D(2024, 2, 1)
        }));
        db.SaveChanges();
    }

    static void SeedCitas(ApplicationDbContext db)
    {
        if (db.cita.Any()) return;

        var pacientes = db.paciente.OrderBy(p => p.Id_Paciente).ToList();
        var doctores  = db.doctor.OrderBy(d => d.Id_Doctor).ToList();

        if (!pacientes.Any() || !doctores.Any()) return;

        db.cita.AddRange(
            new Cita { Paciente_Id=pacientes[0].Id_Paciente, Doctor_Id=doctores[0].Id_Doctor, Fecha_Cita=D(2026,3,10,9,0),  Fecha_Modificacion=D(2026,3,10) },
            new Cita { Paciente_Id=pacientes[1].Id_Paciente, Doctor_Id=doctores[1].Id_Doctor, Fecha_Cita=D(2026,3,12,10,30),Fecha_Modificacion=D(2026,3,12) },
            new Cita { Paciente_Id=pacientes[2].Id_Paciente, Doctor_Id=doctores[2].Id_Doctor, Fecha_Cita=D(2026,3,14,8,0),  Fecha_Modificacion=D(2026,3,14) },
            new Cita { Paciente_Id=pacientes[3].Id_Paciente, Doctor_Id=doctores[3].Id_Doctor, Fecha_Cita=D(2026,4,2,11,0),  Fecha_Modificacion=D(2026,4,2)  },
            new Cita { Paciente_Id=pacientes[4].Id_Paciente, Doctor_Id=doctores[0].Id_Doctor, Fecha_Cita=D(2026,4,5,14,30), Fecha_Modificacion=D(2026,4,5)  },
            new Cita { Paciente_Id=pacientes[5].Id_Paciente, Doctor_Id=doctores[1].Id_Doctor, Fecha_Cita=D(2026,4,8,9,0),   Fecha_Modificacion=D(2026,4,8)  },
            new Cita { Paciente_Id=pacientes[6].Id_Paciente, Doctor_Id=doctores[2].Id_Doctor, Fecha_Cita=D(2026,5,15,10,0), Fecha_Modificacion=D(2026,5,15) },
            new Cita { Paciente_Id=pacientes[7].Id_Paciente, Doctor_Id=doctores[3].Id_Doctor, Fecha_Cita=D(2026,5,20,8,30), Fecha_Modificacion=D(2026,5,20) },
            new Cita { Paciente_Id=pacientes[0].Id_Paciente, Doctor_Id=doctores[2].Id_Doctor, Fecha_Cita=D(2026,6,3,9,0),   Fecha_Modificacion=D(2026,6,3)  },
            new Cita { Paciente_Id=pacientes[2].Id_Paciente, Doctor_Id=doctores[0].Id_Doctor, Fecha_Cita=D(2026,6,10,11,30),Fecha_Modificacion=D(2026,6,10) }
        );
        db.SaveChanges();
    }

    static void SeedDiagnosticos(ApplicationDbContext db)
    {
        if (db.diagnostico.Any()) return;

        var citas = db.cita.OrderBy(c => c.Id_Cita).ToList();
        if (!citas.Any()) return;

        db.diagnostico.AddRange(
            new Diagnostico
            {
                Descripcion="Hipertensión arterial estadio I",
                Comentario="Presión arterial 150/95 mmHg. Se inicia tratamiento con Enalapril 10mg diario. Dieta baja en sodio. Control en 4 semanas.",
                Cita_Id=citas[0].Id_Cita, Fecha_Creacion=citas[0].Fecha_Cita, Fecha_Modificacion=citas[0].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Infección respiratoria alta",
                Comentario="Paciente con fiebre 38.5°C, tos seca y congestión nasal desde hace 3 días. Se receta Amoxicilina 500mg cada 8h por 7 días. Reposo.",
                Cita_Id=citas[1].Id_Cita, Fecha_Creacion=citas[1].Fecha_Cita, Fecha_Modificacion=citas[1].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Gastroenteritis aguda",
                Comentario="Diarrea y vómitos desde hace 24h. Se indica hidratación oral, dieta blanda. Omeprazol 20mg en ayunas. Evaluar si persiste más de 48h.",
                Cita_Id=citas[2].Id_Cita, Fecha_Creacion=citas[2].Fecha_Cita, Fecha_Modificacion=citas[2].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Control prenatal 2do trimestre",
                Comentario="Embarazo de 20 semanas. Signos vitales normales. Se indica Vitamina C y Complejo B. Próximo control en 4 semanas con ecosonograma.",
                Cita_Id=citas[3].Id_Cita, Fecha_Creacion=citas[3].Fecha_Cita, Fecha_Modificacion=citas[3].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Arritmia cardíaca benigna",
                Comentario="Paciente refiere palpitaciones ocasionales. ECG muestra extrasístoles ventriculares aisladas. Sin cardiopatía estructural. Monitoreo ambulatorio.",
                Cita_Id=citas[4].Id_Cita, Fecha_Creacion=citas[4].Fecha_Cita, Fecha_Modificacion=citas[4].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Síndrome de ovario poliquístico",
                Comentario="Ecografía confirma ovarios poliquísticos. Ciclos menstruales irregulares. Se inicia tratamiento hormonal. Ajuste dietético y actividad física.",
                Cita_Id=citas[5].Id_Cita, Fecha_Creacion=citas[5].Fecha_Cita, Fecha_Modificacion=citas[5].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Diabetes tipo 2 descompensada",
                Comentario="Glucemia en ayunas 280 mg/dL. HbA1c 9.2%. Se ajusta dosis de metformina y se agrega Glibenclamida. Control estricto de dieta. Glucometría diaria.",
                Cita_Id=citas[6].Id_Cita, Fecha_Creacion=citas[6].Fecha_Cita, Fecha_Modificacion=citas[6].Fecha_Cita
            },
            new Diagnostico
            {
                Descripcion="Otitis media aguda",
                Comentario="Paciente con dolor de oído derecho, fiebre 37.8°C y disminución auditiva. Se receta Amoxicilina 500mg c/8h por 10 días. Analgésico oral.",
                Cita_Id=citas[7].Id_Cita, Fecha_Creacion=citas[7].Fecha_Cita, Fecha_Modificacion=citas[7].Fecha_Cita
            }
        );
        db.SaveChanges();
    }

    static void SeedFacturas(ApplicationDbContext db)
    {
        if (db.factura.Any()) return;

        var citas = db.cita.OrderBy(c => c.Id_Cita).ToList();
        if (!citas.Any()) return;

        db.factura.AddRange(
            new Factura { Cita_Id=citas[0].Id_Cita, Monto=800m,  Metodo_Pago="Efectivo",           Estado="Pagado",    Fecha_Creacion=citas[0].Fecha_Cita },
            new Factura { Cita_Id=citas[1].Id_Cita, Monto=650m,  Metodo_Pago="Tarjeta de crédito", Estado="Pagado",    Fecha_Creacion=citas[1].Fecha_Cita },
            new Factura { Cita_Id=citas[2].Id_Cita, Monto=500m,  Metodo_Pago="Efectivo",           Estado="Pagado",    Fecha_Creacion=citas[2].Fecha_Cita },
            new Factura { Cita_Id=citas[3].Id_Cita, Monto=1200m, Metodo_Pago="Tarjeta de débito",  Estado="Pagado",    Fecha_Creacion=citas[3].Fecha_Cita },
            new Factura { Cita_Id=citas[4].Id_Cita, Monto=950m,  Metodo_Pago="Transferencia",      Estado="Pendiente", Fecha_Creacion=citas[4].Fecha_Cita },
            new Factura { Cita_Id=citas[5].Id_Cita, Monto=750m,  Metodo_Pago="Efectivo",           Estado="Pendiente", Fecha_Creacion=citas[5].Fecha_Cita },
            new Factura { Cita_Id=citas[6].Id_Cita, Monto=600m,  Metodo_Pago="Tarjeta de crédito", Estado="Pagado",    Fecha_Creacion=citas[6].Fecha_Cita },
            new Factura { Cita_Id=citas[7].Id_Cita, Monto=450m,  Metodo_Pago="Efectivo",           Estado="Cancelado", Fecha_Creacion=citas[7].Fecha_Cita }
        );
        db.SaveChanges();
    }

    static DateTime D(int y, int m, int d, int h = 0, int min = 0) =>
        new DateTime(y, m, d, h, min, 0, DateTimeKind.Utc);
}
