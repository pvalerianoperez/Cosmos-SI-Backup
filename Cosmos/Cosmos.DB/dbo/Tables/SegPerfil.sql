CREATE TABLE [dbo].[SegPerfil] (
    [SegPerfilID]    INT           IDENTITY (1, 1) NOT NULL,
    [SegPerfilClave] NCHAR (4)     CONSTRAINT [DF_SistemaPerfil_PerfilClave] DEFAULT (N'"') NOT NULL,
    [Nombre]         NVARCHAR (50) NOT NULL,
    [NombreCorto]    NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_SegPerfilID] PRIMARY KEY CLUSTERED ([SegPerfilID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegPerfil_SegPerfilClave]
    ON [dbo].[SegPerfil]([SegPerfilClave] ASC);

