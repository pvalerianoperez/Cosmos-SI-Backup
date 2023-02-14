CREATE TABLE [dbo].[SegPerfilOpcionAccion] (
    [SegPerfilOpcionAccionID] INT IDENTITY (1, 1) NOT NULL,
    [SegPerfilOpcionID]       INT NOT NULL,
    [AccionID]                INT NOT NULL,
    CONSTRAINT [PK_SegPerfilOpcionAccionID] PRIMARY KEY CLUSTERED ([SegPerfilOpcionAccionID] ASC),
    CONSTRAINT [FK_SegPerfilOpcionAccion_SegPerfilOpcion] FOREIGN KEY ([SegPerfilOpcionID]) REFERENCES [dbo].[SegPerfilOpcion] ([SegPerfilOpcionID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SegPerfilOpcionAccion_SistemaAccion] FOREIGN KEY ([AccionID]) REFERENCES [dbo].[SistemaAccion] ([AccionID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegPerfilOpcionAccion_SegPerfilOpcionID_AccionID]
    ON [dbo].[SegPerfilOpcionAccion]([SegPerfilOpcionID] ASC, [AccionID] ASC);

