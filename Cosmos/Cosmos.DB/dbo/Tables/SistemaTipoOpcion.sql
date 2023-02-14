CREATE TABLE [dbo].[SistemaTipoOpcion] (
    [TipoOpcionID] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (50) NOT NULL,
    [NombreCorto]  NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_SistemaTipoOpcion] PRIMARY KEY CLUSTERED ([TipoOpcionID] ASC)
);



