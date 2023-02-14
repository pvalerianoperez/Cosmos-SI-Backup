CREATE TABLE [dbo].[AuxIdioma] (
    [AuxIdiomaID]    INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (50) NULL,
    [NombreCorto]    VARCHAR (20) NULL,
    [AuxIdiomaClave] VARCHAR (5)  NOT NULL,
    CONSTRAINT [PK_AuxIdioma] PRIMARY KEY CLUSTERED ([AuxIdiomaID] ASC)
);

