CREATE TABLE [dbo].[SistemaUsuarioIntentos] (
    [UsuarioID]  INT           NOT NULL,
    [Fecha]      DATETIME      NOT NULL,
    [IP]         NVARCHAR (50) NOT NULL,
    [Contrasena] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SistemaUsuarioIntentos] PRIMARY KEY CLUSTERED ([UsuarioID] ASC, [Fecha] ASC)
);



