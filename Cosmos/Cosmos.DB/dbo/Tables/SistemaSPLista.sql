CREATE TABLE [dbo].[SistemaSPLista] (
    [SPListaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]    VARCHAR (50) NOT NULL,
    [SP]        VARCHAR (80) NOT NULL,
    CONSTRAINT [PK_SistemaSPLista] PRIMARY KEY CLUSTERED ([SPListaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaSPLista_SP]
    ON [dbo].[SistemaSPLista]([SP] ASC);

