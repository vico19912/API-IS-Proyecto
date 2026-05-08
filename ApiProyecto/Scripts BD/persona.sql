-- ApiMedico.dbo.Persona definition

-- Drop table

-- DROP TABLE ApiMedico.dbo.Persona;

CREATE TABLE ApiMedico.dbo.Persona (
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