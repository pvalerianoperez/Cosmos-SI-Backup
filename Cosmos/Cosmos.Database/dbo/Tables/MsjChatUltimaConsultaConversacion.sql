CREATE TABLE [dbo].[MsjChatUltimaConsultaConversacion] (
    [UsuarioID]      INT      NOT NULL,
    [ConversacionID] INT      NOT NULL,
    [UltimaConsulta] DATETIME NOT NULL,
    CONSTRAINT [FK_MsjChatUltimaConsultaConversacion_MsjChatConversacion] FOREIGN KEY ([ConversacionID]) REFERENCES [dbo].[MsjChatConversacion] ([ConversacionID]),
    CONSTRAINT [FK_MsjChatUltimaConsultaConversacion_SistemaUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SistemaUsuario] ([UsuarioID]),
    CONSTRAINT [AK_MsjChatUltimaConsultaConversacion_UsuarioId_ConversacionID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [ConversacionID] ASC)
);

