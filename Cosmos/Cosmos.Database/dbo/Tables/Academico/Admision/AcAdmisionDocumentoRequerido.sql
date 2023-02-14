CREATE TABLE [dbo].[AcDocumentosRequeridos]
(
	[DocumentoRequridoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentoID] INT NOT NULL,
	[TipoDocumentoID] INT NOT NULL,
	[SeccionID] INT NOT NULL, 

    [Cantidad] INT NOT NULL, 
    CONSTRAINT [FK_AcAdmision_DocumentoRequerido_DocumentoID] FOREIGN KEY ([DocumentoID]) REFERENCES [AcDocumento]([DocumentoID]), 
    CONSTRAINT [FK_AcAdmision_DocumentoRequerido_TipoDocumentoID] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [AcTipoDocumento]([TipoDocumentoID]),
	CONSTRAINT [FK_AcAdmision_DocumentoRequerido_SeccionID] FOREIGN KEY ([SeccionID]) REFERENCES [AcSeccion]([SeccionID])
)	
