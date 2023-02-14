CREATE TABLE [dbo].[SegUsuario] (
    [SegUsuarioID]      INT            IDENTITY (1, 1) NOT NULL,
    [CorreoElectronico] NVARCHAR (150) NOT NULL,
    [Contrasena]        NVARCHAR (50)  NOT NULL,
    [Nombre]            NVARCHAR (150) NOT NULL,
    [Alias]             NVARCHAR (50)  NOT NULL,
    [Activo]            BIT            NOT NULL,
    [Intentos]          TINYINT        NOT NULL,
    [Bloqueado]         BIT            NOT NULL,
    [UsuarioAD]         NVARCHAR (50)  NOT NULL,
    [Administrador]     BIT            NOT NULL,
    [UltimoAcceso]      DATETIME       NOT NULL,
    [UltimaEmpresaID]   INT            NOT NULL,
    [UltimoModuloID]    INT            NOT NULL,
    [UltimaOpcionID]    INT            NOT NULL,
    [UltimaIP]          NVARCHAR (50)  NOT NULL,
    [LinkFoto]          VARCHAR (250)  NOT NULL,
    [EspPersonaID]      INT            NULL,
    CONSTRAINT [PK_SegUsuario] PRIMARY KEY CLUSTERED ([SegUsuarioID] ASC),
    CONSTRAINT [FK_SegUsuario_EspPersona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID]) ON DELETE SET NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegUsuario_CorreoElectronico]
    ON [dbo].[SegUsuario]([CorreoElectronico] ASC);

