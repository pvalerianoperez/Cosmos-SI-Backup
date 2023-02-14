CREATE TABLE [dbo].[AcAdmisionDocumentoEntregado] (
    [DocumentoEntregadoID] INT IDENTITY (1, 1) NOT NULL,
    [DocumentoID]          INT NOT NULL,
    [TipoDocumentoID]      INT NOT NULL,
    [AspiranteID]          INT NOT NULL,
    [Cantidad]             INT NOT NULL,
    PRIMARY KEY CLUSTERED ([DocumentoEntregadoID] ASC),
    CONSTRAINT [FK_AcAdmision_DocumentoEntregado_DocumentoID] FOREIGN KEY ([DocumentoID]) REFERENCES [dbo].[AcDocumento] ([DocumentoID]),
    CONSTRAINT [FK_AcAdmision_DocumentoEntregado_TipoDocumentoID] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[AcTipoDocumento] ([TipoDocumentoID])
);

