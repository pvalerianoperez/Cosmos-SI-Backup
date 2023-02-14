CREATE TABLE [dbo].[SistemaEstatusTipoDocumento] (
    [SistemaEstatusTipoDocumentoID] INT IDENTITY (1, 1) NOT NULL,
    [SistemaEstatusDocumentoID]     INT NOT NULL,
    [TipoDocumentoID]               INT NOT NULL,
    [Predeterminado]                BIT NOT NULL,
    [Restringido]                   BIT NOT NULL,
    [Monto]                         BIT NOT NULL,
    [Propietario]                   BIT NOT NULL,
    [Sistema]                       BIT NOT NULL,
    [EmpresaID]                     INT NOT NULL,
    CONSTRAINT [PK_SistemaEstatusTipoDocumento] PRIMARY KEY CLUSTERED ([SistemaEstatusTipoDocumentoID] ASC),
    CONSTRAINT [FK_SistemaEstatusTipoDocumento_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID]),
    CONSTRAINT [FK_SistemaEstatusTipoDocumento_SistemaEstatusDocumento] FOREIGN KEY ([SistemaEstatusDocumentoID]) REFERENCES [dbo].[SistemaEstatusDocumento] ([SistemaEstatusDocumentoID])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusTipoDocumento_EmpresaID_SistemaEstatusDocumentoID_TipoDocumentoID]
    ON [dbo].[SistemaEstatusTipoDocumento]([EmpresaID] ASC, [SistemaEstatusDocumentoID] ASC, [TipoDocumentoID] ASC);

