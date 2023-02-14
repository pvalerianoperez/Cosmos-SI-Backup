CREATE TABLE [dbo].[MsjChatConversacionUsuario] (
    [UsuarioID]             INT NOT NULL,
    [ConversacionID]        INT NOT NULL,
    [PermisoConversacionID] INT NOT NULL,
    CONSTRAINT [FK_MsjChatConversacionUsuario_MsjChatConversacion] FOREIGN KEY ([ConversacionID]) REFERENCES [dbo].[MsjChatConversacion] ([ConversacionID]),
    CONSTRAINT [FK_MsjChatConversacionUsuario_MsjChatPermisoConversacion] FOREIGN KEY ([PermisoConversacionID]) REFERENCES [dbo].[MsjChatPermisoConversacion] ([PermisoConversacionID]),
    CONSTRAINT [FK_MsjChatConversacionUsuario_SistemaUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SistemaUsuario] ([UsuarioID]),
    CONSTRAINT [AK_MsjChatConversacionUsuario_UsuarioID_ConversacionID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [ConversacionID] ASC)
);

