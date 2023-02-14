CREATE TABLE [dbo].[SistemaTipoOpcionAccion] (
    [TipoOpcionAccionID] INT IDENTITY (1, 1) NOT NULL,
    [TipoOpcionID]       INT NOT NULL,
    [AccionID]           INT NOT NULL,
    CONSTRAINT [PK_SistemaTipoOpcionAccion] PRIMARY KEY CLUSTERED ([TipoOpcionAccionID] ASC),
    CONSTRAINT [FK_SistemaTipoOpcionAccion_SistemaAccion] FOREIGN KEY ([AccionID]) REFERENCES [dbo].[SistemaAccion] ([AccionID]),
    CONSTRAINT [FK_SistemaTipoOpcionAccion_SistemaTipoOpcion] FOREIGN KEY ([TipoOpcionID]) REFERENCES [dbo].[SistemaTipoOpcion] ([TipoOpcionID])
);



