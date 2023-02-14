CREATE TABLE [dbo].[SistemaTipoRepresentanteCliente] (
    [TipoRepresentanteClienteID]    INT          NOT NULL,
    [TipoRepresentanteClienteClave] VARCHAR (5)  NOT NULL,
    [Nombre]                        VARCHAR (30) NOT NULL,
    [NombreCorto]                   VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([TipoRepresentanteClienteID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SistemaTipoRepresentanteCliente_TipoRepresentanteClienteClave]
    ON [dbo].[SistemaTipoRepresentanteCliente]([TipoRepresentanteClienteClave] ASC);

