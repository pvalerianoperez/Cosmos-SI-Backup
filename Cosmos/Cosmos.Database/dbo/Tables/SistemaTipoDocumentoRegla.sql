CREATE TABLE [dbo].[SistemaTipoDocumentoRegla] (
    [TipoDocumentoReglaID]                 INT IDENTITY (1, 1) NOT NULL,
    [SistemaEstatusTipoDocumentoIDPermite] INT NOT NULL,
    [SistemaEstatusTipoDocumentoID]        INT NOT NULL,
    CONSTRAINT [PK_SistemaTipoDocumentoRegla] PRIMARY KEY CLUSTERED ([TipoDocumentoReglaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoDocumentoRegla_SistemaEstatusTipoDocumentoIDPermite_SistemaEstatusTipoDocumentoID]
    ON [dbo].[SistemaTipoDocumentoRegla]([SistemaEstatusTipoDocumentoIDPermite] ASC, [SistemaEstatusTipoDocumentoID] ASC);

