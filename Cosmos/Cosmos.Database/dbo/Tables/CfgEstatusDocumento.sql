CREATE TABLE [dbo].[CfgEstatusDocumento] (
    [CfgEstatusDocumentoID]         INT          IDENTITY (1, 1) NOT NULL,
    [CfgEstatusDocumentoClave]      VARCHAR (8)  NOT NULL,
    [Nombre]                        VARCHAR (40) NOT NULL,
    [NombreCorto]                   VARCHAR (10) NOT NULL,
    [SistemaEstatusTipoDocumentoID] INT          NOT NULL,
    [Predeterminado]                BIT          NOT NULL,
    CONSTRAINT [PK_CfgEstatusDocumentoID] PRIMARY KEY CLUSTERED ([CfgEstatusDocumentoID] ASC),
    CONSTRAINT [FK_CfgEstatusDocumento_SistemaEstatusTipoDocumento] FOREIGN KEY ([SistemaEstatusTipoDocumentoID]) REFERENCES [dbo].[SistemaEstatusTipoDocumento] ([SistemaEstatusTipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgEstatusDocumento_SistemaEstatusTipoDocumentoID_CfgEstatusDocumentoClave]
    ON [dbo].[CfgEstatusDocumento]([SistemaEstatusTipoDocumentoID] ASC, [CfgEstatusDocumentoClave] ASC);

