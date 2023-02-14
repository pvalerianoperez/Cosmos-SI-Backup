CREATE TABLE [dbo].[MsjComunicaListaDistribucion] (
    [ListaDistribucionID]    INT          IDENTITY (1, 1) NOT NULL,
    [ListaDistribucionClave] VARCHAR (6)  NULL,
    [Nombre]                 VARCHAR (50) NOT NULL,
    [NombreCorto]            VARCHAR (15) NOT NULL,
    [Activa]                 BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ListaDistribucionID] ASC),
    CONSTRAINT [AK_MsjComunicaListaDistribucion_ListaDistribucionClave] UNIQUE NONCLUSTERED ([ListaDistribucionClave] ASC),
    CONSTRAINT [AK_MsjComunicaListaDistribucion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_MsjComunicaListaDistribucion_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);

