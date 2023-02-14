CREATE TABLE [dbo].[SistemaNaturaleza] (
    [NaturalezaID]    INT          IDENTITY (1, 1) NOT NULL,
    [NaturalezaClave] VARCHAR (6)  NOT NULL,
    [Nombre]          VARCHAR (30) NOT NULL,
    [NombreCorto]     VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_SistemaNaturaleza] PRIMARY KEY CLUSTERED ([NaturalezaID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaNaturaleza_NaturalezaClave]
    ON [dbo].[SistemaNaturaleza]([NaturalezaClave] ASC);

