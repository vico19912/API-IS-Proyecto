USE ApiMedico;
GO

-- ============================================================
-- ROLES
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Rol)
BEGIN
    INSERT INTO dbo.Rol (Descripcion, Estado) VALUES
        ('Administrador',  1),
        ('Doctor',         1),
        ('Enfermero',      1),
        ('Recepcionista',  1),
        ('Farmaceutico',   1),
        ('Paciente',       1);
END
GO

-- ============================================================
-- HOSPITALES
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Hospital)
BEGIN
    INSERT INTO dbo.Hospital (Nombre, Direccion, Telefono) VALUES
        ('Hospital Escuela Universitario', 'Blvd. Suyapa, Tegucigalpa',       '2232-6700'),
        ('Hospital San Felipe',            'Col. Miraflores, Tegucigalpa',     '2231-0087'),
        ('Hospital Mario Catarino Rivas',  'Blvd. del Norte, San Pedro Sula',  '2553-0200'),
        ('Clinica Viera',                  'Col. Palmira, Tegucigalpa',        '2239-7800'),
        ('Hospital del Valle',             '3ra Calle SO, San Pedro Sula',     '2516-0000');
END
GO

-- ============================================================
-- ESPECIALIDADES
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Especialidad)
BEGIN
    INSERT INTO dbo.Especialidad (Descripcion) VALUES
        ('Medicina General'),   -- 1
        ('Cardiologia'),        -- 2
        ('Pediatria'),          -- 3
        ('Neurologia'),         -- 4
        ('Ortopedia'),          -- 5
        ('Ginecologia'),        -- 6
        ('Dermatologia'),       -- 7
        ('Oftalmologia'),       -- 8
        ('Psiquiatria'),        -- 9
        ('Oncologia');          -- 10
END
GO

-- ============================================================
-- TIPOS DE EMPLEADO
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Tipo_Empleado)
BEGIN
    INSERT INTO dbo.Tipo_Empleado (Descripcion, Fecha_Creacion, Fecha_Modificacion) VALUES
        ('Tiempo completo',   '2024-01-01', '2024-01-01'),  -- 1
        ('Medio tiempo',      '2024-01-01', '2024-01-01'),  -- 2
        ('Contrato temporal', '2024-01-01', '2024-01-01'),  -- 3
        ('Residente',         '2024-01-01', '2024-01-01'),  -- 4
        ('Practicante',       '2024-01-01', '2024-01-01');  -- 5
END
GO

-- ============================================================
-- PERSONAS
-- Id 1-5  : personal medico (doctores)
-- Id 6-15 : pacientes
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Persona)
BEGIN
    SET IDENTITY_INSERT dbo.Persona ON;
    INSERT INTO dbo.Persona (Id_Persona, DNI, Nombre, Nombre_2, Apellido, Apellido_2, Telefono, Correo, Sexo, Fecha_Nacimiento) VALUES
        -- Doctores
        (1,  '0801198512345', 'Carlos',   'Andres',   'Martinez',  'Lopez',    '98765432', 'carlos.martinez@clinica.com',   'M', '1985-03-12'),
        (2,  '0801199067890', 'Maria',    'Jose',     'Hernandez', 'Reyes',    '97654321', 'maria.hernandez@clinica.com',   'F', '1990-07-25'),
        (3,  '0801197811111', 'Luis',     'Enrique',  'Garcia',    'Mendoza',  '96543210', 'luis.garcia@clinica.com',       'M', '1978-11-05'),
        (4,  '0801199522222', 'Ana',      'Patricia', 'Ramirez',   'Cruz',     '95432109', 'ana.ramirez@clinica.com',       'F', '1995-01-18'),
        (5,  '0801198233333', 'Jorge',    'Alberto',  'Torres',    'Vasquez',  '94321098', 'jorge.torres@clinica.com',      'M', '1982-09-30'),
        -- Pacientes
        (6,  '0801199344444', 'Sofia',    NULL,       'Flores',    'Aguilar',  '93210987', 'sofia.flores@gmail.com',        'F', '1993-04-14'),
        (7,  '0801197055555', 'Roberto',  'Daniel',   'Castillo',  'Morales',  '92109876', 'roberto.castillo@gmail.com',    'M', '1970-06-22'),
        (8,  '0801198866666', 'Laura',    'Isabel',   'Diaz',      'Fuentes',  '91098765', 'laura.diaz@gmail.com',          'F', '1988-12-03'),
        (9,  '0801200077777', 'Miguel',   NULL,       'Sanchez',   'Portillo', '90987654', 'miguel.sanchez@gmail.com',      'M', '2000-02-28'),
        (10, '0801197588888', 'Carmen',   'Rosa',     'Gutierrez', 'Banegas',  '89876543', 'carmen.gutierrez@gmail.com',    'F', '1975-08-17'),
        (11, '0801200299999', 'Pedro',    'Antonio',  'Ruiz',      'Alvarado', '88765432', 'pedro.ruiz@gmail.com',          'M', '2002-05-10'),
        (12, '0801199700000', 'Elena',    NULL,       'Moreno',    'Zelaya',   '87654321', 'elena.moreno@gmail.com',        'F', '1997-11-23'),
        (13, '0801199111122', 'Diego',    'Ramon',    'Vargas',    'Colon',    '86543210', 'diego.vargas@gmail.com',        'M', '1991-07-08'),
        (14, '0801200533333', 'Isabella', NULL,       'Ramos',     'Diaz',     '85432109', 'isabella.ramos@gmail.com',      'F', '2005-03-19'),
        (15, '0801196844444', 'Manuel',   'Eduardo',  'Castillo',  'Reina',    '84321098', 'manuel.castillo@gmail.com',     'M', '1968-09-05');
    SET IDENTITY_INSERT dbo.Persona OFF;
END
GO

-- ============================================================
-- EMPLEADOS
-- Id 1   : Administrador
-- Id 2-6 : Doctores
-- Id 7-8 : Enfermeros
-- Id 9   : Recepcionista
-- Id 10  : Farmaceutico
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Empleado)
BEGIN
    INSERT INTO dbo.Empleado (Password, Hospital_Id, Rol_Id, Tipo_Empleado_Id, Fecha_Ingreso, Fecha_Modificacion) VALUES
        ('Admin2024!',  1, 1, 1, '2015-01-05', '2024-01-10'),  -- 1: Admin
        ('Doctor2024!', 1, 2, 1, '2016-03-10', '2024-01-10'),  -- 2: Dr. Carlos Martinez
        ('Doctor2024!', 1, 2, 1, '2018-07-01', '2024-01-10'),  -- 3: Dra. Maria Hernandez
        ('Doctor2024!', 2, 2, 2, '2019-01-15', '2024-01-10'),  -- 4: Dr. Luis Garcia
        ('Doctor2024!', 3, 2, 1, '2020-06-20', '2024-01-10'),  -- 5: Dra. Ana Ramirez
        ('Doctor2024!', 1, 2, 1, '2017-11-08', '2024-01-10'),  -- 6: Dr. Jorge Torres
        ('Enferm2024!', 1, 3, 1, '2018-02-14', '2024-01-10'),  -- 7: Enfermero H1
        ('Enferm2024!', 2, 3, 3, '2021-05-03', '2024-01-10'),  -- 8: Enfermero H2
        ('Recep2024!',  1, 4, 1, '2019-08-12', '2024-01-10'),  -- 9: Recepcionista
        ('Farm2024!',   1, 5, 1, '2020-03-25', '2024-01-10');  -- 10: Farmaceutico
END
GO

-- ============================================================
-- PERMISOS
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Permiso)
BEGIN
    INSERT INTO dbo.Permiso (Descripcion, Rol_Id) VALUES
        ('Gestionar usuarios',          1),
        ('Gestionar roles',             1),
        ('Ver reportes',                1),
        ('Configurar sistema',          1),
        ('Ver historial clinico',       2),
        ('Crear diagnostico',           2),
        ('Emitir receta medica',        2),
        ('Agendar cita medica',         2),
        ('Registrar signos vitales',    3),
        ('Administrar medicamentos',    3),
        ('Ver citas asignadas',         3),
        ('Registrar paciente',          4),
        ('Gestionar citas',             4),
        ('Ver agenda medica',           4),
        ('Dispensar medicamentos',      5),
        ('Gestionar inventario',        5),
        ('Ver recetas medicas',         5),
        ('Ver sus citas',               6),
        ('Ver sus recetas',             6),
        ('Actualizar datos personales', 6);
END
GO

-- ============================================================
-- DOCTORES  (Empleados 2-6 | Personas 1-5)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Doctor)
BEGIN
    INSERT INTO dbo.Doctor (Numero_Colegiatura, Empleado_Id, Persona_Id, Especialidad_Id) VALUES
        ('COL-10001', 2, 1, 2),   -- Carlos Martinez   - Cardiologia
        ('COL-10002', 3, 2, 1),   -- Maria Hernandez   - Medicina General
        ('COL-10003', 4, 3, 3),   -- Luis Garcia       - Pediatria
        ('COL-10004', 5, 4, 4),   -- Ana Ramirez       - Neurologia
        ('COL-10005', 6, 5, 6);   -- Jorge Torres      - Ginecologia
END
GO

-- ============================================================
-- PACIENTES  (Personas 6-15 -> Id_Paciente 1-10)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Paciente)
BEGIN
    INSERT INTO dbo.Paciente (Persona_Id, Fecha_Creacion, Fecha_Modificacion) VALUES
        (6,  '2024-01-15', '2024-01-15'),  -- 1: Sofia Flores
        (7,  '2024-02-03', '2024-02-03'),  -- 2: Roberto Castillo
        (8,  '2024-02-20', '2024-02-20'),  -- 3: Laura Diaz
        (9,  '2024-03-07', '2024-03-07'),  -- 4: Miguel Sanchez
        (10, '2024-03-18', '2024-03-18'),  -- 5: Carmen Gutierrez
        (11, '2024-04-05', '2024-04-05'),  -- 6: Pedro Ruiz
        (12, '2024-04-22', '2024-04-22'),  -- 7: Elena Moreno
        (13, '2024-05-10', '2024-05-10'),  -- 8: Diego Vargas
        (14, '2024-05-28', '2024-05-28'),  -- 9: Isabella Ramos
        (15, '2024-06-15', '2024-06-15');  -- 10: Manuel Castillo
END
GO

-- ============================================================
-- CITAS  (Pacientes 1-10 | Doctores 1-5 -> Id_Cita 1-12)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Cita)
BEGIN
    INSERT INTO dbo.Cita (Paciente_Id, Doctor_Id, Fecha_Cita, Fecha_Modificacion) VALUES
        (1,  1, '2026-03-10 09:00', '2026-03-10'),  --  1: Sofia     -> Carlos  (Cardio)
        (2,  2, '2026-03-12 10:30', '2026-03-12'),  --  2: Roberto   -> Maria   (Med.Gral)
        (3,  3, '2026-03-14 08:00', '2026-03-14'),  --  3: Laura     -> Luis    (Pediatria)
        (4,  4, '2026-04-02 11:00', '2026-04-02'),  --  4: Miguel    -> Ana     (Neurologia)
        (5,  1, '2026-04-05 14:30', '2026-04-05'),  --  5: Carmen    -> Carlos  (Cardio)
        (6,  5, '2026-04-08 09:00', '2026-04-08'),  --  6: Pedro     -> Jorge   (Gineco)
        (7,  2, '2026-05-15 10:00', '2026-05-15'),  --  7: Elena     -> Maria   (Med.Gral)
        (8,  3, '2026-05-20 08:30', '2026-05-20'),  --  8: Diego     -> Luis    (Pediatria)
        (9,  2, '2026-05-28 11:00', '2026-05-28'),  --  9: Isabella  -> Maria   (Med.Gral)
        (10, 4, '2026-06-03 09:00', '2026-06-03'),  -- 10: Manuel    -> Ana     (Neurologia)
        (1,  2, '2026-06-10 11:30', '2026-06-10'),  -- 11: Sofia     -> Maria   (2da visita)
        (3,  1, '2026-06-20 14:00', '2026-06-20');  -- 12: Laura     -> Carlos  (2da visita)
END
GO

-- ============================================================
-- DIAGNOSTICOS  (para citas 1-10)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Diagnostico)
BEGIN
    INSERT INTO dbo.Diagnostico (Descripcion, Comentario, Cita_Id, Fecha_Creacion, Fecha_Modificacion) VALUES
        (
            'Hipertension arterial estadio I',
            'Presion arterial 150/95 mmHg. Se inicia tratamiento con Enalapril 10mg diario. Dieta baja en sodio y ejercicio moderado. Control en 4 semanas.',
            1, '2026-03-10', '2026-03-10'
        ),
        (
            'Infeccion respiratoria alta',
            'Paciente con fiebre 38.5 C, tos seca y congestion nasal desde hace 3 dias. Se prescribe Amoxicilina 500mg c/8h por 7 dias y Paracetamol 500mg c/8h. Reposo relativo.',
            2, '2026-03-12', '2026-03-12'
        ),
        (
            'Gastroenteritis aguda',
            'Diarrea y vomitos desde hace 24h. Se indica hidratacion oral abundante, dieta blanda. Omeprazol 20mg en ayunas. Evaluar si persiste mas de 48 horas.',
            3, '2026-03-14', '2026-03-14'
        ),
        (
            'Migrana cronica con aura',
            'Cefalea pulsatil 8/10, acompanada de fotofobia y nauseas. Patron de 2-3 episodios por mes. Se prescribe Ibuprofeno 400mg en crisis. Se deriva a neurologia para manejo preventivo.',
            4, '2026-04-02', '2026-04-02'
        ),
        (
            'Arritmia cardiaca benigna',
            'Paciente refiere palpitaciones ocasionales sin sincope. ECG muestra extrasistoles ventriculares aisladas. Sin cardiopatia estructural por ecocardiograma. Se indica monitoreo Holter 24h.',
            5, '2026-04-05', '2026-04-05'
        ),
        (
            'Control prenatal 2do trimestre',
            'Embarazo de 20 semanas. Signos vitales normales. Ecosonograma fetal con anatomia normal. Se indica Vitamina C 1000mg y Complejo B. Proximo control en 4 semanas.',
            6, '2026-04-08', '2026-04-08'
        ),
        (
            'Anemia ferropenica moderada',
            'Hemoglobina 9.2 g/dL, ferritina 8 ng/mL. Se indica sulfato ferroso 300mg c/12h por 3 meses y dieta rica en hierro. Control con biometria hematica completa en 6 semanas.',
            7, '2026-05-15', '2026-05-15'
        ),
        (
            'Otitis media aguda',
            'Paciente con otalgia derecha intensa, fiebre 37.8 C e hipoacusia leve. Otoscopia: membrana timpanica eritematosa. Se prescribe Amoxicilina 500mg c/8h por 10 dias y Diclofenac 50mg c/8h.',
            8, '2026-05-20', '2026-05-20'
        ),
        (
            'Diabetes tipo 2 con mal control metabolico',
            'Glucemia en ayunas 285 mg/dL. HbA1c 9.4%. Se ajusta Metformina a 850mg c/12h y se agrega Glibenclamida 5mg. Glucometria diaria obligatoria. Consulta nutricionista.',
            9, '2026-05-28', '2026-05-28'
        ),
        (
            'Cervicalgia mecanica',
            'Dolor cervical 6/10 con irradiacion a hombro derecho desde hace 2 semanas. Se indica Diclofenac 50mg c/8h por 5 dias, fisioterapia y ejercicios de estiramiento cervical.',
            10, '2026-06-03', '2026-06-03'
        );
END
GO

-- ============================================================
-- TIPOS DE MEDICAMENTO
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Tipo_Medicamento)
BEGIN
    INSERT INTO dbo.Tipo_Medicamento (Descripcion) VALUES
        ('Analgesico'),       -- 1
        ('Antibiotico'),      -- 2
        ('Antiinflamatorio'), -- 3
        ('Antihipertensivo'), -- 4
        ('Vitaminas'),        -- 5
        ('Antiacido');        -- 6
END
GO

-- ============================================================
-- MEDICAMENTOS
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Medicamento)
BEGIN
    INSERT INTO dbo.Medicamento (Descripcion, Tipo_Medicamento_Id) VALUES
        ('Paracetamol 500mg',       1),  -- Analgesico
        ('Ibuprofeno 400mg',        3),  -- Antiinflamatorio
        ('Amoxicilina 500mg',       2),  -- Antibiotico
        ('Azitromicina 500mg',      2),  -- Antibiotico
        ('Enalapril 10mg',          4),  -- Antihipertensivo
        ('Losartan 50mg',           4),  -- Antihipertensivo
        ('Vitamina C 1000mg',       5),  -- Vitaminas
        ('Complejo B',              5),  -- Vitaminas
        ('Omeprazol 20mg',          6),  -- Antiacido
        ('Diclofenac sodico 50mg',  3);  -- Antiinflamatorio
END
GO

-- ============================================================
-- FACTURAS  (una por cada cita, para las 12 citas)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Factura)
BEGIN
    INSERT INTO dbo.Factura (Cita_Id, Monto, Metodo_Pago, Estado, Fecha_Creacion) VALUES
        (1,   800.00, 'Efectivo',           'Pagado',    '2026-03-10'),
        (2,   650.00, 'Tarjeta de credito', 'Pagado',    '2026-03-12'),
        (3,   500.00, 'Efectivo',           'Pagado',    '2026-03-14'),
        (4,   950.00, 'Tarjeta de debito',  'Pagado',    '2026-04-02'),
        (5,   800.00, 'Transferencia',      'Pagado',    '2026-04-05'),
        (6,  1200.00, 'Efectivo',           'Pagado',    '2026-04-08'),
        (7,   600.00, 'Tarjeta de credito', 'Pendiente', '2026-05-15'),
        (8,   550.00, 'Efectivo',           'Pendiente', '2026-05-20'),
        (9,   700.00, 'Tarjeta de debito',  'Pendiente', '2026-05-28'),
        (10,  950.00, 'Transferencia',      'Cancelado', '2026-06-03'),
        (11,  700.00, 'Efectivo',           'Pendiente', '2026-06-10'),
        (12,  800.00, 'Tarjeta de credito', 'Pendiente', '2026-06-20');
END
GO
