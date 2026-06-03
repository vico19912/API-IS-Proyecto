IF NOT EXISTS (SELECT name
FROM sys.databases
WHERE name = 'ApiMedico')
BEGIN
    CREATE DATABASE ApiMedico;
END
GO

USE ApiMedico;
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Rol' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Rol
    (
        Id_Rol int IDENTITY(1,1) NOT NULL,
        Descripcion varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Estado int NOT NULL,
        Fecha_Creacion datetime2(0) DEFAULT getdate() NULL,
        Fecha_Modificacion datetime2(0) DEFAULT getdate() NULL,
        CONSTRAINT Rol_PK PRIMARY KEY (Id_Rol),
        CONSTRAINT Rol_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Persona' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Persona
    (
        Id_Persona int NOT NULL,
        Nombre_1 varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Nombre_2 varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        Apellido_1 varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Apellido_2 varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        Telefono varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Correo varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Genero char(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Fecha_Nacimiento datetime2(0) NOT NULL,
        DNI varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Permiso' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Permiso
    (
        Id_Permiso int IDENTITY(1,1) NOT NULL,
        Descripcion varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Rol_Id int NULL,
        Fecha_Creacion datetime2(0) DEFAULT getdate() NOT NULL,
        Fecha_Modificacion datetime DEFAULT getdate() NULL,
        CONSTRAINT Permiso_PK PRIMARY KEY (Id_Permiso),
        CONSTRAINT Permiso_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END

GO
IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Paciente' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Paciente
    (
        Id_Paciente int IDENTITY(1,1) NOT NULL,
        Persona_Id int NOT NULL,
        Fecha_Creacion datetime DEFAULT getdate() NULL,
        Fecha_Modificacion datetime DEFAULT getdate() NULL,
        CONSTRAINT Paciente_PK PRIMARY KEY (Id_Paciente)
    );
END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Doctor' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Doctor
    (
        Id_Doctor int IDENTITY(1,1) NOT NULL,
        Numero_Colegiatura varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Empleado_Id int NULL,
        Persona_Id int NULL,
        Especialidad_Id int NULL,
        CONSTRAINT Doctor_PK PRIMARY KEY (Id_Doctor),
        CONSTRAINT Doctor_UNIQUE_Colegiatura UNIQUE (Numero_Colegiatura)
    );
END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Especialidad' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Especialidad
    (
        Id_Especialidad int IDENTITY(1,1) NOT NULL,
        Descripcion varchar(200) NOT NULL,
        Fecha_Creacion datetime2(0) DEFAULT getdate() NULL,
        Fecha_Modificacion datetime2(0) DEFAULT getdate() NULL,
        CONSTRAINT Especialidad_PK PRIMARY KEY (Id_Especialidad),
        CONSTRAINT Especialidad_UNIQUE UNIQUE (Descripcion)
    );

END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Empleado' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Empleado
    (
        Id_Empleado int IDENTITY(1,1) NOT NULL,
        Password varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
        Hospital_Id int NULL,
        Rol_Id int NULL,
        Tipo_Empleado_Id int NULL,
        Fecha_Ingreso datetime DEFAULT getdate() NULL,
        Fecha_Modificacion datetime NULL,
        CONSTRAINT Empleado_PK PRIMARY KEY (Id_Empleado)
    );

END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Hospital' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Hospital
    (
        Id_Hospital int IDENTITY(1,1) NOT NULL,
        Nombre varchar(100) NOT NULL,
        Telefono varchar(20) NULL,
        Direccion varchar(200) NULL,
        Fecha_Creacion datetime DEFAULT getdate() NULL,
        Fecha_Modificacion datetime DEFAULT getdate() NULL,
        CONSTRAINT Hsopital_PK PRIMARY KEY (Id_Hospital),
        CONSTRAINT Hsopital_UNIQUE_Nombre UNIQUE (Nombre)
    );

END
GO

IF NOT EXISTS (SELECT *
FROM sys.tables
WHERE name = 'Tipo_Empleado' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ApiMedico.dbo.Tipo_Empleado
    (
        Id_Tipo int IDENTITY(1,1) NOT NULL,
        Descripcion varchar(100) NOT NULL,
        Fecha_Creacion datetime DEFAULT getdate() NULL,
        Fecha_Modificacion datetime DEFAULT getdate() NULL,
        CONSTRAINT Tipo_Empleado_UNIQUE UNIQUE (Id_Tipo),
        CONSTRAINT Tipo_Empleado_UNIQUE_1 UNIQUE (Descripcion)
    );

END
GO