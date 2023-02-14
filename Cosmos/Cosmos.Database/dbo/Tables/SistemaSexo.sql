CREATE TABLE [dbo].[SistemaSexo] (
    [SexoID]      INT          IDENTITY (1, 1) NOT NULL,
    [SexoClave]   VARCHAR (6)  NOT NULL,
    [Nombre]      VARCHAR (30) NOT NULL,
    [NombreCorto] VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_SistemaSexo] PRIMARY KEY CLUSTERED ([SexoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Sexo]
    ON [dbo].[SistemaSexo]([SexoClave] ASC);

