CREATE TABLE [dbo].[CfgTipoCliente] (
    [CfgTipoClienteID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoClienteClave] VARCHAR (5)  NOT NULL,
    [Nombre]              VARCHAR (50) NOT NULL,
    [NombreCorto]         VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_CfgTipoCliente] PRIMARY KEY CLUSTERED ([CfgTipoClienteID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TipoCliente_TipoClienteClave]
    ON [dbo].[CfgTipoCliente]([CfgTipoClienteClave] ASC);

