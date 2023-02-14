CREATE TABLE [dbo].[SistemaEstatusRegla] (
    [EstatusReglaID]                       INT IDENTITY (1, 1) NOT NULL,
    [SistemaEstatusTipoDocumentoIDPermite] INT NOT NULL,
    [SistemaEstatusTipoDocumentoID]        INT NOT NULL,
    CONSTRAINT [PK_SistemaEstatusRegla] PRIMARY KEY CLUSTERED ([EstatusReglaID] ASC),
    CONSTRAINT [FK_SistemaEstatusRegla_SistemaEstatusTipoDocumento] FOREIGN KEY ([SistemaEstatusTipoDocumentoID]) REFERENCES [dbo].[SistemaEstatusTipoDocumento] ([SistemaEstatusTipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusRegla_SistemaEstatusTipoDocumentoIDPermite_SistemaEstatusTipoDocumentoID]
    ON [dbo].[SistemaEstatusRegla]([SistemaEstatusTipoDocumentoIDPermite] ASC, [SistemaEstatusTipoDocumentoID] ASC);

