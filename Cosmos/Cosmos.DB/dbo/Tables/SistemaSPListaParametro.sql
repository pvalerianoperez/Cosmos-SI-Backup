CREATE TABLE [dbo].[SistemaSPListaParametro] (
    [SPListaParametroID] INT          IDENTITY (1, 1) NOT NULL,
    [SPListaID]          INT          NOT NULL,
    [Parametro]          VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_SistemaSPListaParametro] PRIMARY KEY CLUSTERED ([SPListaParametroID] ASC),
    CONSTRAINT [FK_SistemaSPListaParametro_SistemaSPLista] FOREIGN KEY ([SPListaID]) REFERENCES [dbo].[SistemaSPLista] ([SPListaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaSPListaParametro]
    ON [dbo].[SistemaSPListaParametro]([SPListaID] ASC, [Parametro] ASC);

