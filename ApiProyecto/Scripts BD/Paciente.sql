-- ApiMedico.dbo.Paciente definition

-- Drop table

-- DROP TABLE ApiMedico.dbo.Paciente;

CREATE TABLE ApiMedico.dbo.Paciente (
	Id_Paciente int IDENTITY(1,1) NOT NULL,
	Persona_Id int NOT NULL,
	Cita_Id int NULL,
	CONSTRAINT Paciente_PK PRIMARY KEY (Id_Paciente)
);

ALTER TABLE ApiMedico.dbo.Paciente ADD Fecha_Creacion datetime DEFAULT getdate() NULL;
ALTER TABLE ApiMedico.dbo.Paciente ADD Fecha_Modificacion datetime DEFAULT getdate() NULL;
