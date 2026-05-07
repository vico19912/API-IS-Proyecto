-- ApiMedico.dbo.Permiso definition

-- Drop table

-- DROP TABLE ApiMedico.dbo.Permiso;

CREATE TABLE ApiMedico.dbo.Permiso (
	Id_Permiso int IDENTITY(1,1) NOT NULL,
	Descripcion varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Rol_Id int NULL,
	Fecha_Creacion datetime2(0) DEFAULT getdate() NOT NULL,
	Fecha_Modificacion datetime DEFAULT getdate() NULL,
	CONSTRAINT Permiso_PK PRIMARY KEY (Id_Permiso),
	CONSTRAINT Permiso_UNIQUE_Descripcion UNIQUE (Descripcion)
);