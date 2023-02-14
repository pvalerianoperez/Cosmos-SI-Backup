CREATE TABLE [dbo].[MsjComunicaReporteEnvio] (
    [ReporteEnvioID] INT            IDENTITY (1, 1) NOT NULL,
    [RemitenteID]    INT            NOT NULL,
    [Tema]           NVARCHAR (100) NOT NULL,
    [Fecha]          DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([ReporteEnvioID] ASC),
    CONSTRAINT [FK_MsjComunicaReporteEnvio_SegUsuario] FOREIGN KEY ([RemitenteID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID])
);

