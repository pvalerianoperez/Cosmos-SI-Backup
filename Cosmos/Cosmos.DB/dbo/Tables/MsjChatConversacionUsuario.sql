CREATE TABLE [dbo].[MsjChatConversacionUsuario] (
    [UsuarioID]             INT NOT NULL,
    [ConversacionID]        INT NOT NULL,
    [PermisoConversacionID] INT NOT NULL,
    CONSTRAINT [PK_MsjChatConversacionUsuario] PRIMARY KEY CLUSTERED ([UsuarioID] ASC),
    CONSTRAINT [FK_MsjChatConversacionUsuario_MsjChatConversacion] FOREIGN KEY ([ConversacionID]) REFERENCES [dbo].[MsjChatConversacion] ([ConversacionID]),
    CONSTRAINT [FK_MsjChatConversacionUsuario_MsjChatPermisoConversacion] FOREIGN KEY ([PermisoConversacionID]) REFERENCES [dbo].[MsjChatPermisoConversacion] ([PermisoConversacionID]),
    CONSTRAINT [FK_MsjChatConversacionUsuario_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [AK_MsjChatConversacionUsuario_UsuarioID_ConversacionID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [ConversacionID] ASC)
);



