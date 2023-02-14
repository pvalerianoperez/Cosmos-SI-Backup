
CREATE TABLE [dbo].[SistemaGrupoRegla] (
    [SistemaGrupoReglaID]           INT IDENTITY (1, 1) NOT NULL,
    [SistemaGrupoEstatusID]         INT NOT NULL,
    [SistemaEstatusTipoDocumentoID] INT NOT NULL,
    [Activo]                        BIT NOT NULL,
    CONSTRAINT [PK_SistemaReporteRegla] PRIMARY KEY CLUSTERED ([SistemaGrupoReglaID] ASC),
    CONSTRAINT [FK_SistemaGrupoRegla_SistemaEstatusTipoDocumento] FOREIGN KEY ([SistemaEstatusTipoDocumentoID]) REFERENCES [dbo].[SistemaEstatusTipoDocumento] ([SistemaEstatusTipoDocumentoID]),
    CONSTRAINT [FK_SistemaGrupoRegla_SistemaGrupoEstatus] FOREIGN KEY ([SistemaGrupoEstatusID]) REFERENCES [dbo].[SistemaGrupoEstatus] ([SistemaGrupoEstatusID])
);


GO


GO


GO


GO


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaGrupoRegla_SistemaGrupoEstatusID_SistemaEstatusTipoDocumentoID]
    ON [dbo].[SistemaGrupoRegla]([SistemaGrupoEstatusID] ASC, [SistemaEstatusTipoDocumentoID] ASC);

