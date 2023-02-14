CREATE TABLE [dbo].[MsjComunicaReporteEnvioMensaje] (
    [MsjComunicaReporteEnvioMensaje] INT NOT NULL,
    [ReporteEnvioID]                 INT NOT NULL,
    [MensajeID]                      INT NOT NULL,
    CONSTRAINT [PK_MsjComunicaReporteEnvioMensaje] PRIMARY KEY CLUSTERED ([MsjComunicaReporteEnvioMensaje] ASC),
    CONSTRAINT [FK_MsjComunicaReporteEnvioMensaje_MsjComunicaMensaje] FOREIGN KEY ([MensajeID]) REFERENCES [dbo].[MsjComunicaMensaje] ([MensajeID]),
    CONSTRAINT [FK_MsjComunicaReporteEnvioMensaje_MsjComunicaReporteEnvio] FOREIGN KEY ([ReporteEnvioID]) REFERENCES [dbo].[MsjComunicaReporteEnvio] ([ReporteEnvioID]),
    CONSTRAINT [FK_MsjComunicaReporteEnvioMensaje_MsjComunicaReporteEnvio_UNIQUE] UNIQUE NONCLUSTERED ([ReporteEnvioID] ASC, [MensajeID] ASC)
);



GO

CREATE INDEX [IX_MsjComunicaReporteEnvioMensaje_ReporteEnvioID] ON [dbo].[MsjComunicaReporteEnvioMensaje] ([ReporteEnvioID])
