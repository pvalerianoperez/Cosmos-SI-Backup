CREATE TABLE [dbo].[AcGiroEmpresa]
(
	[GiroEmpresaID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NULL,
	CONSTRAINT [Ak_Admision_AdmisionGiroEmpresa] UNIQUE ([Nombre])
)
