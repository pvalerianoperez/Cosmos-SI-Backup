CREATE TABLE [dbo].[AcAdmisionProfesion]
(
	[ProfesionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NULL,
	CONSTRAINT [AK_AcAdmision_AdmisionProfesion] UNIQUE ([Nombre])
);
