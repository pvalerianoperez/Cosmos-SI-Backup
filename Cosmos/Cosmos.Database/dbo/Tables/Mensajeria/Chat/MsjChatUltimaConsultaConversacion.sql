CREATE TABLE [dbo].[MsjChatUltimaConsultaConversacion] (
    [MsjChatUltimaConsultaConversacion] INT      NOT NULL,
    [UsuarioID]                         INT      NOT NULL,
    [ConversacionID]                    INT      NOT NULL,
    [UltimaConsulta]                    DATETIME NOT NULL,
    CONSTRAINT [PK_MsjChatUltimaConsultaConversacion] PRIMARY KEY CLUSTERED ([MsjChatUltimaConsultaConversacion] ASC),
    CONSTRAINT [FK_MsjChatUltimaConsultaConversacion_MsjChatConversacion] FOREIGN KEY ([ConversacionID]) REFERENCES [dbo].[MsjChatConversacion] ([ConversacionID]),
    CONSTRAINT [FK_MsjChatUltimaConsultaConversacion_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [AK_MsjChatUltimaConsultaConversacion_UsuarioId_ConversacionID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [ConversacionID] ASC)
);


