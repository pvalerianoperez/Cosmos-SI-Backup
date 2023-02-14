CREATE TABLE [dbo].[SistemaEstatusDocumentoOpcion] (
    [EstatusDocumentoOpcionID] INT IDENTITY (1, 1) NOT NULL,
    [OpcionID]                 INT NOT NULL,
    [EstatusTipoDocumentoID]   INT NOT NULL,
    CONSTRAINT [PK_SistemaEstatusDocumentoOpcion] PRIMARY KEY CLUSTERED ([EstatusDocumentoOpcionID] ASC),
    CONSTRAINT [FK_SistemaEstatusDocumentoOpcion_SistemaEstatusDocumento] FOREIGN KEY ([EstatusTipoDocumentoID]) REFERENCES [dbo].[SistemaEstatusTipoDocumento] ([SistemaEstatusTipoDocumentoID]),
    CONSTRAINT [FK_SistemaEstatusDocumentoOpcion_SistemaOpcion] FOREIGN KEY ([OpcionID]) REFERENCES [dbo].[SistemaOpcion] ([OpcionID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusDocumentoOpcion]
    ON [dbo].[SistemaEstatusDocumentoOpcion]([OpcionID] ASC, [EstatusTipoDocumentoID] ASC);

