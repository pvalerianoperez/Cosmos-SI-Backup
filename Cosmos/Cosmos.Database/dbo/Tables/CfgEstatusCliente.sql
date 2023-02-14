CREATE TABLE [dbo].[CfgEstatusCliente] (
    [CfgEstatusClienteID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgEstatusClienteClave] VARCHAR (6)  NULL,
    [Nombre]                 VARCHAR (40) NULL,
    [NombreCorto]            VARCHAR (10) NULL,
    [EstatusPersonaID]       INT          NULL,
    CONSTRAINT [PK_CfgEstatusCliente] PRIMARY KEY CLUSTERED ([CfgEstatusClienteID] ASC),
    CONSTRAINT [FK_EstatusCliente_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EstatusCliente_EstatusClienteClave]
    ON [dbo].[CfgEstatusCliente]([CfgEstatusClienteClave] ASC);

