CREATE TABLE [dbo].[AcDocumento] (
    [DocumentoID]    INT           IDENTITY (1, 1) NOT NULL,
    [DocumentoClave] VARCHAR (6)   NULL,
    [Nombre]         VARCHAR (80)  NOT NULL,
    [NombreCorto]    VARCHAR (15)  NULL,
    [Descripcion]    VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([DocumentoID] ASC),
    CONSTRAINT [AK_AcDocumento_DocumentoClave] UNIQUE NONCLUSTERED ([DocumentoClave] ASC),
    CONSTRAINT [AK_AcDocumento_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

