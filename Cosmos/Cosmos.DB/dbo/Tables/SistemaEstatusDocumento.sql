CREATE TABLE [dbo].[SistemaEstatusDocumento] (
    [SistemaEstatusDocumentoID]    INT          IDENTITY (1, 1) NOT NULL,
    [SistemaEstatusDocumentoClave] VARCHAR (4)  NOT NULL,
    [Nombre]                       VARCHAR (30) NOT NULL,
    [NombreCorto]                  VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_SistemaEstatusDocumento] PRIMARY KEY CLUSTERED ([SistemaEstatusDocumentoID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusDocumento_SistemaEstatusDocumentoClave]
    ON [dbo].[SistemaEstatusDocumento]([SistemaEstatusDocumentoClave] ASC);

