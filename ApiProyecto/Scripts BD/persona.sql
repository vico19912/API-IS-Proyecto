-- ApiMedico.dbo.Persona definition

-- Drop table

-- DROP TABLE ApiMedico.dbo.Persona;

CREATE TABLE ApiMedico.dbo.Persona (
	Id_Persona int IDENTITY(1,1) NOT NULL,
	DNI varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Nombre varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Nombre_2 varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Apellido_2 varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Apellido varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Telefono varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Correo varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Sexo char(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	CONSTRAINT Persona_UNIQUE_DNI UNIQUE (DNI),
	CONSTRAINT Persona_UNIQUE_Telefono UNIQUE (Telefono),
	CONSTRAINT Persona_UNIQUE_mail UNIQUE (Correo)
);