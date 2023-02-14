CREATE TABLE [dbo].[SegUsuarioPerfil] (
    [SegUsuarioPerfilID] INT IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]       INT NOT NULL,
    [SegPerfilID]        INT NOT NULL,
    [EmpresaID]          INT NOT NULL,
    CONSTRAINT [PK_SegUsuarioPerfil] PRIMARY KEY CLUSTERED ([SegUsuarioPerfilID] ASC),
    CONSTRAINT [FK_SegUsuarioPerfil_SegPerfil] FOREIGN KEY ([SegPerfilID]) REFERENCES [dbo].[SegPerfil] ([SegPerfilID]),
    CONSTRAINT [FK_SegUsuarioPerfil_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SegUsuarioPerfil_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);

