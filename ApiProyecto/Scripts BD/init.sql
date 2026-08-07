IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ApiMedico')
BEGIN
    CREATE DATABASE ApiMedico;
END
GO

USE ApiMedico;
GO

-- =========================================================
-- ROL
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rol' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Rol (
        Id_Rol             int IDENTITY(1,1) NOT NULL,
        Descripcion        varchar(100) NOT NULL,
        Estado             int NOT NULL DEFAULT 1,
        Fecha_Creacion     datetime2(0) DEFAULT GETDATE() NULL,
        Fecha_Modificacion datetime2(0) DEFAULT GETDATE() NULL,
        CONSTRAINT Rol_PK               PRIMARY KEY (Id_Rol),
        CONSTRAINT Rol_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

-- =========================================================
-- PERSONA  (columnas alineadas con el modelo EF Core)
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Persona' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Persona (
        Id_Persona         int IDENTITY(1,1) NOT NULL,
        DNI                varchar(20)  NOT NULL,
        Nombre             varchar(100) NOT NULL,
        Nombre_2           varchar(100) NULL,
        Apellido           varchar(100) NOT NULL,
        Apellido_2         varchar(100) NULL,
        Telefono           varchar(15)  NOT NULL,
        Correo             varchar(100) NOT NULL,
        Sexo               char(1)      NOT NULL,
        Fecha_Nacimiento   datetime2(0) NOT NULL,
        CONSTRAINT Persona_PK PRIMARY KEY (Id_Persona)
    );
END
GO

-- =========================================================
-- PERMISO
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Permiso' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Permiso (
        Id_Permiso         int IDENTITY(1,1) NOT NULL,
        Descripcion        varchar(100) NOT NULL,
        Rol_Id             int NULL,
        Fecha_Creacion     datetime2(0) DEFAULT GETDATE() NOT NULL,
        Fecha_Modificacion datetime      DEFAULT GETDATE() NULL,
        CONSTRAINT Permiso_PK               PRIMARY KEY (Id_Permiso),
        CONSTRAINT Permiso_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

-- =========================================================
-- HOSPITAL
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Hospital' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Hospital (
        Id_Hospital        int IDENTITY(1,1) NOT NULL,
        Nombre             varchar(100) NOT NULL,
        Direccion          varchar(200) NULL,
        Telefono           varchar(20)  NULL,
        Fecha_Creacion     datetime DEFAULT GETDATE() NULL,
        Fecha_Modificacion datetime DEFAULT GETDATE() NULL,
        CONSTRAINT Hospital_PK          PRIMARY KEY (Id_Hospital),
        CONSTRAINT Hospital_UNIQUE_Nombre UNIQUE (Nombre)
    );
END
GO

-- =========================================================
-- TIPO_EMPLEADO
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Tipo_Empleado' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Tipo_Empleado (
        Id_Tipo            int IDENTITY(1,1) NOT NULL,
        Descripcion        varchar(100) NOT NULL,
        Fecha_Creacion     datetime NULL,
        Fecha_Modificacion datetime NULL,
        CONSTRAINT Tipo_Empleado_PK               PRIMARY KEY (Id_Tipo),
        CONSTRAINT Tipo_Empleado_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

-- =========================================================
-- EMPLEADO
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Empleado' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Empleado (
        Id_Empleado        int IDENTITY(1,1) NOT NULL,
        Password           varchar(255) NOT NULL,
        Hospital_Id        int NULL,
        Rol_Id             int NULL,
        Tipo_Empleado_Id   int NULL,
        Fecha_Ingreso      datetime DEFAULT GETDATE() NULL,
        Fecha_Modificacion datetime NULL,
        CONSTRAINT Empleado_PK PRIMARY KEY (Id_Empleado)
    );
END
GO

-- =========================================================
-- ESPECIALIDAD
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Especialidad' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Especialidad (
        Id_Especialidad    int IDENTITY(1,1) NOT NULL,
        Descripcion        varchar(200) NOT NULL,
        Fecha_Creacion     datetime2(0) DEFAULT GETDATE() NULL,
        Fecha_Modificacion datetime2(0) DEFAULT GETDATE() NULL,
        CONSTRAINT Especialidad_PK               PRIMARY KEY (Id_Especialidad),
        CONSTRAINT Especialidad_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

-- =========================================================
-- DOCTOR
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Doctor' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Doctor (
        Id_Doctor          int IDENTITY(1,1) NOT NULL,
        Numero_Colegiatura varchar(100) NOT NULL,
        Empleado_Id        int NULL,
        Persona_Id         int NULL,
        Especialidad_Id    int NULL,
        CONSTRAINT Doctor_PK                PRIMARY KEY (Id_Doctor),
        CONSTRAINT Doctor_UNIQUE_Colegiatura UNIQUE (Numero_Colegiatura)
    );
END
GO

-- =========================================================
-- PACIENTE
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Paciente' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Paciente (
        Id_Paciente        int IDENTITY(1,1) NOT NULL,
        Persona_Id         int NOT NULL,
        Fecha_Creacion     datetime DEFAULT GETDATE() NULL,
        Fecha_Modificacion datetime DEFAULT GETDATE() NULL,
        CONSTRAINT Paciente_PK PRIMARY KEY (Id_Paciente)
    );
END
GO

-- =========================================================
-- CITA
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Cita' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Cita (
        Id_Cita            int IDENTITY(1,1) NOT NULL,
        Paciente_Id        int NULL,
        Doctor_Id          int NULL,
        Fecha_Cita         datetime NOT NULL,
        Fecha_Modificacion datetime DEFAULT GETDATE() NOT NULL,
        CONSTRAINT Cita_PK PRIMARY KEY (Id_Cita)
    );
END
GO

-- =========================================================
-- DIAGNOSTICO
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Diagnostico' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Diagnostico (
        Id_Diagnostico     int IDENTITY(1,1) NOT NULL,
        Descripcion        varchar(500)  NOT NULL,
        Comentario         varchar(1000) NOT NULL,
        Cita_Id            int NOT NULL,
        Fecha_Creacion     datetime NOT NULL,
        Fecha_Modificacion datetime NOT NULL,
        CONSTRAINT Diagnostico_PK PRIMARY KEY (Id_Diagnostico)
    );
END
GO

-- =========================================================
-- TIPO_MEDICAMENTO  (tabla nueva)
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Tipo_Medicamento' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Tipo_Medicamento (
        Id_Tipo     int IDENTITY(1,1) NOT NULL,
        Descripcion varchar(100) NOT NULL,
        CONSTRAINT Tipo_Medicamento_PK               PRIMARY KEY (Id_Tipo),
        CONSTRAINT Tipo_Medicamento_UNIQUE_Descripcion UNIQUE (Descripcion)
    );
END
GO

-- =========================================================
-- MEDICAMENTO  (tabla nueva)
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Medicamento' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Medicamento (
        Id_Medicamento      int IDENTITY(1,1) NOT NULL,
        Descripcion         varchar(200) NOT NULL,
        Tipo_Medicamento_Id int NOT NULL,
        CONSTRAINT Medicamento_PK      PRIMARY KEY (Id_Medicamento),
        CONSTRAINT Medicamento_Tipo_FK FOREIGN KEY (Tipo_Medicamento_Id)
            REFERENCES dbo.Tipo_Medicamento(Id_Tipo)
    );
END
GO

-- =========================================================
-- FACTURA  (tabla nueva)
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Factura' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.Factura (
        Id_Factura         int IDENTITY(1,1) NOT NULL,
        Cita_Id            int NOT NULL,
        Monto              decimal(10,2) NOT NULL,
        Metodo_Pago        varchar(50) NOT NULL DEFAULT 'Efectivo',
        Estado             varchar(20) NOT NULL DEFAULT 'Pendiente',
        Fecha_Creacion     datetime2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT Factura_PK      PRIMARY KEY (Id_Factura),
        CONSTRAINT Factura_Cita_FK FOREIGN KEY (Cita_Id)
            REFERENCES dbo.Cita(Id_Cita)
    );
END
GO
