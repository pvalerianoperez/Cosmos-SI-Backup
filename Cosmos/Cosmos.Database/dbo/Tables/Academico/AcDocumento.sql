CREATE TABLE [dbo].[AcDocumento]
(
	[DocumentoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentoClave]		VARCHAR (6)   NULL,
    [Nombre]				VARCHAR (80)  NOT NULL,
    [NombreCorto]			VARCHAR (15)  NULL,
    [Descripcion]			VARCHAR (150) NULL,
    CONSTRAINT [AK_AcDocumento_DocumentoClave] UNIQUE ([DocumentoClave]),
    CONSTRAINT [AK_AcDocumento_Nombre] UNIQUE ([Nombre])
)
