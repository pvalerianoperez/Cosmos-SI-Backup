CREATE TABLE [dbo].[MsjComunicaMensaje] (
    [MensajeID]            INT            IDENTITY (1, 1) NOT NULL,
    [CanalComunicacionID]  INT            NOT NULL,
    [TipoMensajeID]        INT            NOT NULL,
    [RemitenteID]          INT            NOT NULL,
    [DestinatarioID]       INT            NOT NULL,
    [FechaRegistro]        DATETIME       NOT NULL,
    [FechaProgramadaEnvio] DATETIME       NULL,
    [FechaEnviado]         DATETIME       NULL,
    [FechaLeido]           DATETIME       NULL,
    [FechaBorrado]         DATETIME       NULL,
    [Tema]                 NVARCHAR (100) NOT NULL,
    [Mensaje]              NVARCHAR (MAX) NOT NULL,
    [RequiereAcuse]        BIT            DEFAULT ((0)) NOT NULL,
    [Acusado]              BIT            NULL,
    [Error]                NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([MensajeID] ASC),
    CONSTRAINT [FK_MsjComunicaMensaje_MsjComunicaCanalComunicacion] FOREIGN KEY ([CanalComunicacionID]) REFERENCES [dbo].[MsjComunicaCanalComunicacion] ([CanalComunicacionID]),
    CONSTRAINT [FK_MsjComunicaMensaje_MsjComunicaTipoMensaje] FOREIGN KEY ([TipoMensajeID]) REFERENCES [dbo].[MsjComunicaTipoMensaje] ([TipoMensajeID]),
    CONSTRAINT [FK_MsjComunicaMensaje_SegUsuario] FOREIGN KEY ([RemitenteID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [FK_MsjComunicaMensaje_SegUsuario_1] FOREIGN KEY ([DestinatarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID])
);


