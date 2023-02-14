CREATE TABLE [dbo].[SistemaOpcionTipoOpcion] (
    [OpcionTipoOpcionID] INT IDENTITY (1, 1) NOT NULL,
    [OpcionID]           INT NOT NULL,
    [TipoOpcionID]       INT NOT NULL,
    CONSTRAINT [PK_SistemaOpcionTipoOpcion] PRIMARY KEY CLUSTERED ([OpcionTipoOpcionID] ASC),
    CONSTRAINT [FK_SistemaOpcionTipoOpcion_SistemaOpcion] FOREIGN KEY ([OpcionID]) REFERENCES [dbo].[SistemaOpcion] ([OpcionID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SistemaOpcionTipoOpcion_SistemaTipoOpcion] FOREIGN KEY ([TipoOpcionID]) REFERENCES [dbo].[SistemaTipoOpcion] ([TipoOpcionID])
);




GO
CREATE NONCLUSTERED INDEX [IX_SistemaOpcionTipoOpcion_OpcionID_TipoOpcionID]
    ON [dbo].[SistemaOpcionTipoOpcion]([OpcionID] ASC, [TipoOpcionID] ASC);

