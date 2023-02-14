CREATE TABLE [dbo].[MsjComunicaUltimaConsultaMensaje] (
    [MsjComunicaUltimaConsultaMensajeId] INT      NOT NULL,
    [UsuarioID]                          INT      NOT NULL,
    [FechaUltimaConsulta]                DATETIME NOT NULL,
    CONSTRAINT [PK_MsjComunicaUltimaConsultaMensaje] PRIMARY KEY CLUSTERED ([MsjComunicaUltimaConsultaMensajeId] ASC),
    CONSTRAINT [FK_MsjComunicaUltimaConsultaMensaje_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID])
);



GO

CREATE INDEX [IX_MsjComunicaUltimaConsultaMensaje_UsuarioID] ON [dbo].[MsjComunicaUltimaConsultaMensaje] ([UsuarioID])
