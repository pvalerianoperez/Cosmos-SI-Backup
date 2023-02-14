CREATE TABLE [dbo].[AcAreaDeFormacion]
(
	[AreaDeFormacionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AreaDeFormacionClave] VARCHAR(6) NOT NULL, 
    [Nombre] VARCHAR(80) NOT NULL, 
    [NombreCorto] VARCHAR(15) NOT NULL, 
    CONSTRAINT [AK_AcAreaDeFormacion_AreaDeFormacionClave] UNIQUE ([AreaDeFormacionClave]), 
    CONSTRAINT [AK_AcAreaDeFormacion_Nombre] UNIQUE ([Nombre]), 
    CONSTRAINT [AK_AcAreaDeFormacion_NombreCorto] UNIQUE ([NombreCorto])
)