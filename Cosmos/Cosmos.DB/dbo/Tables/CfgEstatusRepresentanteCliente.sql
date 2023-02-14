CREATE TABLE [dbo].[CfgEstatusRepresentanteCliente] (
    [CfgEstatusRepresentanteClienteID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgEstatusRepresentanteClienteClave] VARCHAR (6)  NULL,
    [Nombre]                              VARCHAR (40) NOT NULL,
    [NombreCorto]                         VARCHAR (10) NOT NULL,
    [EstatusPersonaID]                    INT          NULL,
    CONSTRAINT [PK_CfgEstatusRepresentanteCliente] PRIMARY KEY CLUSTERED ([CfgEstatusRepresentanteClienteID] ASC),
    CONSTRAINT [FK_EstatusRepresentanteCliente_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EstatusRepresentanteCliente_EstatusRepresentanteClienteClave]
    ON [dbo].[CfgEstatusRepresentanteCliente]([CfgEstatusRepresentanteClienteClave] ASC);

