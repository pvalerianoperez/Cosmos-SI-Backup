CREATE TABLE [dbo].[AcTipoDocumento]
(
	[TipoDocumentoID]		INT NOT NULL PRIMARY KEY IDENTITY,
	[TipoDocumentoClave]	VARCHAR (6)   NULL,
    [Nombre]				VARCHAR (80)  NOT NULL,
    [NombreCorto]			VARCHAR (15)  NULL,
    [Descripcion]			VARCHAR (150) NULL,
    CONSTRAINT [AK_AcTipoDocumento_DocumentoClave] UNIQUE ([TipoDocumentoClave]),
    CONSTRAINT [AK_AcTipoDocumento_Nombre] UNIQUE ([Nombre])
)
