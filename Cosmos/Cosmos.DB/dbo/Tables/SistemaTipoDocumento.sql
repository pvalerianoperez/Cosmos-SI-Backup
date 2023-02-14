CREATE TABLE [dbo].[SistemaTipoDocumento] (
    [TipoDocumentoID]       INT          IDENTITY (1, 1) NOT NULL,
    [TipoDocumentoClave]    VARCHAR (10) NOT NULL,
    [Nombre]                VARCHAR (30) NOT NULL,
    [NombreCorto]           VARCHAR (30) NOT NULL,
    [Activo]                BIT          NOT NULL,
    [ModuloID]              INT          NOT NULL,
    [AsignarFolioAlGuardar] BIT          NOT NULL,
    CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED ([TipoDocumentoID] ASC),
    CONSTRAINT [FK_SistemaTipoDocumento_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoDocumento_TipoDocumentoClave]
    ON [dbo].[SistemaTipoDocumento]([TipoDocumentoClave] ASC);

