CREATE TABLE [dbo].[AcAdmisionDocumentoEntregado]
(
	[DocumentoEntregadoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentoID] INT NOT NULL,
	[TipoDocumentoID] INT NOT NULL, 
	[AspiranteID] INT NOT NULL, 
    [Cantidad] INT NOT NULL, 
    CONSTRAINT [FK_AcAdmision_DocumentoEntregado_DocumentoID] FOREIGN KEY ([DocumentoID]) REFERENCES [AcDocumento]([DocumentoID]), 
    CONSTRAINT [FK_AcAdmision_DocumentoEntregado_TipoDocumentoID] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [AcTipoDocumento]([TipoDocumentoID])
)
