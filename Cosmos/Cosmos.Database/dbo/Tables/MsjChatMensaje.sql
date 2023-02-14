CREATE TABLE [dbo].[MsjChatMensaje] (
    [MensajeID]      INT      IDENTITY (1, 1) NOT NULL,
    [UsuarioID]      INT      NOT NULL,
    [ConversacionID] INT      NOT NULL,
    [TipoMensajeID]  INT      NOT NULL,
    [Mensaje]        TEXT     NOT NULL,
    [Creado]         DATETIME NOT NULL,
    [Borrado]        DATETIME NULL,
    PRIMARY KEY CLUSTERED ([MensajeID] ASC),
    CONSTRAINT [FK_MsjChatMessages_MsjChatConversacion] FOREIGN KEY ([ConversacionID]) REFERENCES [dbo].[MsjChatConversacion] ([ConversacionID]),
    CONSTRAINT [FK_MsjChatMessages_MsjChatTipoMensaje] FOREIGN KEY ([TipoMensajeID]) REFERENCES [dbo].[MsjChatTipoMensaje] ([TipoMensajeID]),
    CONSTRAINT [FK_MsjChatMessages_SistemaUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SistemaUsuario] ([UsuarioID])
);

