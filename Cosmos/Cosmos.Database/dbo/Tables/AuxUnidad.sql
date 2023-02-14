CREATE TABLE [dbo].[AuxUnidad] (
    [AuxUnidadID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxUnidadClave] VARCHAR (5)  NOT NULL,
    [Nombre]         VARCHAR (25) NOT NULL,
    [NombreCorto]    VARCHAR (8)  NOT NULL,
    [Estatus]        CHAR (1)     NOT NULL,
    CONSTRAINT [PK_AuxUnidadID] PRIMARY KEY CLUSTERED ([AuxUnidadID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AuxUnidad_AuxUnidadClave]
    ON [dbo].[AuxUnidad]([AuxUnidadClave] ASC);

