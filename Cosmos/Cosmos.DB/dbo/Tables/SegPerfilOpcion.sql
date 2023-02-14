CREATE TABLE [dbo].[SegPerfilOpcion] (
    [SegPerfilOpcionID] INT IDENTITY (1, 1) NOT NULL,
    [SegPerfilID]       INT NOT NULL,
    [OpcionID]          INT NOT NULL,
    CONSTRAINT [PK_SegPerfilOpcionID] PRIMARY KEY CLUSTERED ([SegPerfilOpcionID] ASC),
    CONSTRAINT [FK_SegPerfilOpcion_SegPerfil] FOREIGN KEY ([SegPerfilID]) REFERENCES [dbo].[SegPerfil] ([SegPerfilID]),
    CONSTRAINT [FK_SegPerfilOpcion_SistemaOpcion] FOREIGN KEY ([OpcionID]) REFERENCES [dbo].[SistemaOpcion] ([OpcionID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegPerfilOpcion_SegPerfilID_OpcionID]
    ON [dbo].[SegPerfilOpcion]([SegPerfilID] ASC, [OpcionID] ASC);

