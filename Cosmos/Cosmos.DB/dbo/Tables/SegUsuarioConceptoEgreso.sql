CREATE TABLE [dbo].[SegUsuarioConceptoEgreso] (
    [SegUsuarioConceptoEgresoID] INT IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]               INT NOT NULL,
    [PpalConceptoEgresoID]       INT NOT NULL,
    CONSTRAINT [PK_SegUsuarioConceptoEgreso] PRIMARY KEY CLUSTERED ([SegUsuarioConceptoEgresoID] ASC),
    CONSTRAINT [FK_SegUsuarioConceptoEgreso_PpalConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_SegUsuarioConceptoEgreso_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE
);

