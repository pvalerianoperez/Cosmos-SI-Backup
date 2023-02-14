CREATE TABLE [dbo].[MsjComunicaUsuarioDeviceToken] (
    [MsjComunicaUsuarioDeviceToken] INT NOT NULL,
    [UsuarioID]                     INT NOT NULL,
    [DeviceTokenID]                 INT NOT NULL,
    CONSTRAINT [PK_MsjComunicaUsuarioDeviceToken] PRIMARY KEY CLUSTERED ([MsjComunicaUsuarioDeviceToken] ASC),
    CONSTRAINT [FK_MsjComunicaUsuarioDeviceToken_MsjComunicaDeviceToken] FOREIGN KEY ([DeviceTokenID]) REFERENCES [dbo].[MsjComunicaDeviceToken] ([DeviceTokenID]),
    CONSTRAINT [FK_MsjComunicaUsuarioDeviceToken_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [AK_MsjComunicaUsuarioDeviceToken_UsuarioID] UNIQUE NONCLUSTERED ([DeviceTokenID] ASC),
    CONSTRAINT [AK_MsjComunicaUsuarioDeviceToken_UsuarioID_DeviceTokenID] UNIQUE NONCLUSTERED ([UsuarioID] ASC, [DeviceTokenID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_MsjComunicaUsuarioDeviceToken_UsuarioID]
    ON [dbo].[MsjComunicaUsuarioDeviceToken]([UsuarioID] ASC);

