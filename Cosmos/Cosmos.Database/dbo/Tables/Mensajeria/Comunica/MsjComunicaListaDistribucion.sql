CREATE TABLE [dbo].[MsjComunicaListaDistribucion]
(
	[ListaDistribucionID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ListaDistribucionClave] VARCHAR(6), 
    [Nombre] VARCHAR(50) NOT NULL, 
    [NombreCorto] VARCHAR(15) NOT NULL, 
    [Activa] BIT NOT NULL,  
    CONSTRAINT [AK_MsjComunicaListaDistribucion_ListaDistribucionClave] UNIQUE ([ListaDistribucionClave]),
    CONSTRAINT [AK_MsjComunicaListaDistribucion_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_MsjComunicaListaDistribucion_NombreCorto] UNIQUE ([NombreCorto]),
)
