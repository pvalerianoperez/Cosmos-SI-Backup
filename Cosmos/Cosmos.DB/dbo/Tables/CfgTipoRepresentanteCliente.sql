CREATE TABLE [dbo].[CfgTipoRepresentanteCliente] (
    [CfgTipoRepresentanteClienteID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoRepresentanteClienteClave] VARCHAR (4)  NOT NULL,
    [Nombre]                           VARCHAR (50) NOT NULL,
    [NombreCorto]                      VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_CfgTipoRepresentanteCliente] PRIMARY KEY CLUSTERED ([CfgTipoRepresentanteClienteID] ASC)
);

