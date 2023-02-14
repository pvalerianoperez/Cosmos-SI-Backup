CREATE TABLE [dbo].[AcAdmisionMedioContacto]
(
	[MedioContactoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NULL,
	CONSTRAINT [AK_AcAdmision_AdmisionMedioContacto] UNIQUE ([Nombre])
)
