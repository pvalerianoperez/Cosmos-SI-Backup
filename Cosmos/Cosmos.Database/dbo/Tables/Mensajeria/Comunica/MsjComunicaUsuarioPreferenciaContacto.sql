CREATE TABLE [dbo].[MsjComunicaUsuarioPreferenciaContacto] (
    [UsuarioID]           INT NOT NULL,
    [CanalComunicacionID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC),
    CONSTRAINT [FK_MsjComunicaUsuarioPreferenciaContacto_MsjComunicaCanalComunicacion] FOREIGN KEY ([CanalComunicacionID]) REFERENCES [dbo].[MsjComunicaCanalComunicacion] ([CanalComunicacionID]),
    CONSTRAINT [FK_MsjComunicaUsuarioPreferenciaContacto_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [AK_MsjComunicaUsuarioPreferenciaContacto_UsuarioID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [CanalComunicacionID] ASC)
);



GO


