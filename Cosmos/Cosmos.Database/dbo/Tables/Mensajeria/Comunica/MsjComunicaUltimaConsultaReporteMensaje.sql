CREATE TABLE [dbo].[MsjComunicaUltimaConsultaReporteMensaje] (
    [UsuarioID]           INT      NOT NULL,
    [FechaUltimaConsulta] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC),
    CONSTRAINT [FK_MsjComunicaUltimaConsultaReporteMensaje_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID])
);


