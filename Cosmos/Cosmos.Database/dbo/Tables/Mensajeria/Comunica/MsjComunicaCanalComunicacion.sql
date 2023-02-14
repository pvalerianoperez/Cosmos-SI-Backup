CREATE TABLE [dbo].[MsjComunicaCanalComunicacion]
(
	[CanalComunicacionID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[CanalComunicacionClave] VARCHAR(6) NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [NombreCorto] NVARCHAR(15) NOT NULL, 
    [Activo] BIT NOT NULL, 
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_CanalComunicacionClave] UNIQUE ([CanalComunicacionClave]),
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_NombreCorto] UNIQUE ([NombreCorto]),
)
