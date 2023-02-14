CREATE TABLE [dbo].[AcAdmisionServicioSeguimiento]
(
	[ServicioSeguimientoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NULL,
	CONSTRAINT [AK_AcAdmision_AdmisionServicioSeguimiento] UNIQUE ([Nombre])
)
