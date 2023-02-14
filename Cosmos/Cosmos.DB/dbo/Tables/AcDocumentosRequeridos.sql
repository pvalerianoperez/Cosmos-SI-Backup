CREATE TABLE [dbo].[AcDocumentosRequeridos] (
    [DocumentoRequridoID] INT IDENTITY (1, 1) NOT NULL,
    [DocumentoID]         INT NOT NULL,
    [TipoDocumentoID]     INT NOT NULL,
    [SeccionID]           INT NOT NULL,
    [Cantidad]            INT NOT NULL,
    PRIMARY KEY CLUSTERED ([DocumentoRequridoID] ASC),
    CONSTRAINT [FK_AcAdmision_DocumentoRequerido_DocumentoID] FOREIGN KEY ([DocumentoID]) REFERENCES [dbo].[AcDocumento] ([DocumentoID]),
    CONSTRAINT [FK_AcAdmision_DocumentoRequerido_SeccionID] FOREIGN KEY ([SeccionID]) REFERENCES [dbo].[AcSeccion] ([SeccionID]),
    CONSTRAINT [FK_AcAdmision_DocumentoRequerido_TipoDocumentoID] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[AcTipoDocumento] ([TipoDocumentoID])
);

