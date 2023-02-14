
CREATE TABLE [dbo].[SistemaBitacoraEstatus] (
    [BitacoraEstatusID]                 INT      IDENTITY (1, 1) NOT NULL,
    [TipoDocumentoID]                   INT      NOT NULL,
    [DocumentoID]                       INT      NOT NULL,
    [UsuarioID]                         INT      NOT NULL,
    [SistemaEstatusDocumentoID]         INT      NOT NULL,
    [SistemaEstatusDocumentoIDAnterior] INT      NOT NULL,
    [FechaHora]                         DATETIME NOT NULL,
    CONSTRAINT [PK_SistemaBitacoraEstatus] PRIMARY KEY CLUSTERED ([BitacoraEstatusID] ASC),
    CONSTRAINT [FK_SistemaBitacoraEstatus_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [FK_SistemaBitacoraEstatus_SistemaEstatusDocumento] FOREIGN KEY ([SistemaEstatusDocumentoIDAnterior]) REFERENCES [dbo].[SistemaEstatusDocumento] ([SistemaEstatusDocumentoID]),
    CONSTRAINT [FK_SistemaBitacoraEstatus_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO


GO


GO


GO


GO


GO


GO


