CREATE TABLE [dbo].[SistemaOpcionLista] (
    [OpcionListaID] INT IDENTITY (1, 1) NOT NULL,
    [OpcionID]      INT NOT NULL,
    [SPListaID]     INT NOT NULL,
    CONSTRAINT [PK_SistemaOpcionLista] PRIMARY KEY CLUSTERED ([OpcionListaID] ASC),
    CONSTRAINT [FK_SistemaOpcionLista_SistemaOpcion] FOREIGN KEY ([OpcionID]) REFERENCES [dbo].[SistemaOpcion] ([OpcionID]),
    CONSTRAINT [FK_SistemaOpcionLista_SistemaSPLista] FOREIGN KEY ([SPListaID]) REFERENCES [dbo].[SistemaSPLista] ([SPListaID])
);

