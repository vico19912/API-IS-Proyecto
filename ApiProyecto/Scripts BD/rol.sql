-- ApiMedico.dbo.Rol definition

-- Drop table

-- DROP TABLE ApiMedico.dbo.Rol;

CREATE TABLE ApiMedico.dbo.Rol (
	Id_Rol int IDENTITY(1,1) NOT NULL,
	Descripcion varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Estado int NOT NULL,
	Fecha_Creacion datetime2(0) DEFAULT getdate() NULL,
	Fecha_Modificacion datetime2(0) DEFAULT getdate() NULL,
	CONSTRAINT Rol_PK PRIMARY KEY (Id_Rol),
	CONSTRAINT Rol_UNIQUE_Descripcion UNIQUE (Descripcion)
);