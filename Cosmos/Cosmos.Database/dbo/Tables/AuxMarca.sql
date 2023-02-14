CREATE TABLE [dbo].[AuxMarca] (
    [AuxMarcaID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxMarcaClave] VARCHAR (4)  NOT NULL,
    [Nombre]        VARCHAR (25) NOT NULL,
    [NombreCorto]   VARCHAR (8)  NOT NULL,
    [Activo]        CHAR (1)     NOT NULL,
    CONSTRAINT [PK_Auxmarca] PRIMARY KEY CLUSTERED ([AuxMarcaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Marca_MarcaClave]
    ON [dbo].[AuxMarca]([AuxMarcaClave] ASC);

