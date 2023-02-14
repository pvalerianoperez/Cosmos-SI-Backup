CREATE TABLE [dbo].[AcTipoDocumento] (
    [TipoDocumentoID]    INT           IDENTITY (1, 1) NOT NULL,
    [TipoDocumentoClave] VARCHAR (6)   NULL,
    [Nombre]             VARCHAR (80)  NOT NULL,
    [NombreCorto]        VARCHAR (15)  NULL,
    [Descripcion]        VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([TipoDocumentoID] ASC),
    CONSTRAINT [AK_AcTipoDocumento_DocumentoClave] UNIQUE NONCLUSTERED ([TipoDocumentoClave] ASC),
    CONSTRAINT [AK_AcTipoDocumento_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

