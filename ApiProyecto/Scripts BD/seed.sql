USE ApiMedico;
GO

-- Roles
IF NOT EXISTS (SELECT 1 FROM dbo.Rol)
BEGIN
    INSERT INTO dbo.Rol (Descripcion, Estado) VALUES
        ('Administrador',   1),
        ('Doctor',          1),
        ('Enfermero',       1),
        ('Recepcionista',   1),
        ('Farmaceutico',    1),
        ('Paciente',        1);
END
GO

-- Personas
IF NOT EXISTS (SELECT 1 FROM dbo.Persona)
BEGIN
    INSERT INTO dbo.Persona (Id_Persona, Nombre_1, Nombre_2, Apellido_1, Apellido_2, Telefono, Correo, Genero, Fecha_Nacimiento, DNI) VALUES
        (1,  'Carlos',   'Andres',   'Martinez',  'Lopez',    '98765432', 'carlos.martinez@clinica.com',   'M', '1985-03-12', '0801198512345'),
        (2,  'Maria',    'Jose',     'Hernandez', 'Reyes',    '97654321', 'maria.hernandez@clinica.com',   'F', '1990-07-25', '0801199067890'),
        (3,  'Luis',     NULL,       'Garcia',    'Mendoza',  '96543210', 'luis.garcia@clinica.com',       'M', '1978-11-05', '0801197811111'),
        (4,  'Ana',      'Patricia', 'Ramirez',   'Cruz',     '95432109', 'ana.ramirez@clinica.com',       'F', '1995-01-18', '0801199522222'),
        (5,  'Jorge',    'Alberto',  'Torres',    'Vasquez',  '94321098', 'jorge.torres@clinica.com',      'M', '1982-09-30', '0801198233333'),
        (6,  'Sofia',    NULL,       'Flores',    'Aguilar',  '93210987', 'sofia.flores@clinica.com',      'F', '1993-04-14', '0801199344444'),
        (7,  'Roberto',  'Daniel',   'Castillo',  'Morales',  '92109876', 'roberto.castillo@clinica.com',  'M', '1970-06-22', '0801197055555'),
        (8,  'Laura',    'Isabel',   'Diaz',      'Fuentes',  '91098765', 'laura.diaz@clinica.com',        'F', '1988-12-03', '0801198866666'),
        (9,  'Miguel',   NULL,       'Sanchez',   'Portillo', '90987654', 'miguel.sanchez@clinica.com',    'M', '2000-02-28', '0801200077777'),
        (10, 'Carmen',   'Rosa',     'Gutierrez', 'Banegas',  '89876543', 'carmen.gutierrez@clinica.com',  'F', '1975-08-17', '0801197588888');
END
GO

-- Hospitales
IF NOT EXISTS (SELECT 1 FROM dbo.Hospital)
BEGIN
    INSERT INTO dbo.Hospital (Nombre, Direccion, Telefono) VALUES
        ('Hospital Escuela Universitario',      'Blvd. Suyapa, Tegucigalpa',            '2232-6700'),
        ('Hospital San Felipe',                 'Col. Miraflores, Tegucigalpa',          '2231-0087'),
        ('Hospital Mario Catarino Rivas',       'Blvd. del Norte, San Pedro Sula',       '2553-0200'),
        ('Clínica Viera',                       'Col. Palmira, Tegucigalpa',             '2239-7800'),
        ('Hospital del Valle',                  '3ra Calle SO, San Pedro Sula',          '2516-0000');
END
GO

-- Especialidades
IF NOT EXISTS (SELECT 1 FROM dbo.Especialidad)
BEGIN
    INSERT INTO dbo.Especialidad (Descripcion) VALUES
        ('Medicina General'),
        ('Cardiología'),
        ('Pediatría'),
        ('Neurología'),
        ('Ortopedia'),
        ('Ginecología'),
        ('Dermatología'),
        ('Oftalmología'),
        ('Psiquiatría'),
        ('Oncología');
END
GO

-- Tipos de empleado
IF NOT EXISTS (SELECT 1 FROM dbo.Tipo_Empleado)
BEGIN
    INSERT INTO dbo.Tipo_Empleado (Descripcion) VALUES
        ('Tiempo completo'),
        ('Medio tiempo'),
        ('Contrato temporal'),
        ('Residente'),
        ('Practicante');
END
GO

-- Empleados  (Hospital_Id: 1-5 | Rol_Id: 1=Administrador 2=Doctor 3=Enfermero 4=Recepcionista 5=Farmaceutico | Tipo_Empleado_Id: 1=Tiempo completo 2=Medio tiempo 3=Contrato)
IF NOT EXISTS (SELECT 1 FROM dbo.Empleado)
BEGIN
    INSERT INTO dbo.Empleado (Password, Hospital_Id, Rol_Id, Tipo_Empleado_Id) VALUES
        ('Admin2024!',    1, 1, 1),   -- Administrador HC Escuela, tiempo completo
        ('Doctor2024!',   1, 2, 1),   -- Doctor HC Escuela, tiempo completo
        ('Doctor2024!',   1, 2, 1),   -- Doctor HC Escuela, tiempo completo
        ('Doctor2024!',   2, 2, 2),   -- Doctor San Felipe, medio tiempo
        ('Doctor2024!',   3, 2, 1),   -- Doctor Mario Rivas, tiempo completo
        ('Enferm2024!',   1, 3, 1),   -- Enfermero HC Escuela, tiempo completo
        ('Enferm2024!',   2, 3, 3),   -- Enfermero San Felipe, contrato
        ('Recep2024!',    1, 4, 1),   -- Recepcionista HC Escuela, tiempo completo
        ('Recep2024!',    4, 4, 2),   -- Recepcionista Clínica Viera, medio tiempo
        ('Farm2024!',     1, 5, 1);   -- Farmaceutico HC Escuela, tiempo completo
END
GO

-- Permisos  (Rol_Id: 1=Administrador 2=Doctor 3=Enfermero 4=Recepcionista 5=Farmaceutico 6=Paciente)
IF NOT EXISTS (SELECT 1 FROM dbo.Permiso)
BEGIN
    INSERT INTO dbo.Permiso (Descripcion, Rol_Id) VALUES
        -- Administrador
        ('Gestionar usuarios',          1),
        ('Gestionar roles',             1),
        ('Ver reportes',                1),
        ('Configurar sistema',          1),
        -- Doctor
        ('Ver historial clinico',       2),
        ('Crear diagnostico',           2),
        ('Emitir receta medica',        2),
        ('Agendar cita medica',         2),
        -- Enfermero
        ('Registrar signos vitales',    3),
        ('Administrar medicamentos',    3),
        ('Ver citas asignadas',         3),
        -- Recepcionista
        ('Registrar paciente',          4),
        ('Gestionar citas',             4),
        ('Ver agenda medica',           4),
        -- Farmaceutico
        ('Dispensar medicamentos',      5),
        ('Gestionar inventario',        5),
        ('Ver recetas medicas',         5),
        -- Paciente
        ('Ver sus citas',               6),
        ('Ver sus recetas',             6),
        ('Actualizar datos personales', 6);
END
GO

-- Doctores  (Empleado_Id: 2-5 son los empleados con Rol=Doctor | Persona_Id: 1-10 | Especialidad_Id: 1-10)
IF NOT EXISTS (SELECT 1 FROM dbo.Doctor)
BEGIN
    INSERT INTO dbo.Doctor (Numero_Colegiatura, Empleado_Id, Persona_Id, Especialidad_Id) VALUES
        ('COL-10001', 2,  1,  2),   -- Carlos Martinez   | Cardiología      | HC Escuela
        ('COL-10002', 3,  2,  1),   -- Maria Hernandez    | Medicina General | HC Escuela
        ('COL-10003', 4,  3,  3),   -- Luis Garcia        | Pediatría        | San Felipe
        ('COL-10004', 5,  4,  4),   -- Ana Ramirez        | Neurología       | Mario Rivas
        ('COL-10005', 2,  5,  6);   -- Jorge Torres       | Ginecología      | HC Escuela
END
GO
