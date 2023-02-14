CREATE TABLE [dbo].[CfgEstatusContactoPersonal] (
    [CfgEstatusContactoPersonalID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgEstatusContactoPersonalClave] VARCHAR (6)  NULL,
    [Nombre]                          VARCHAR (40) NULL,
    [NombreCorto]                     VARCHAR (10) NULL,
    [EstatusPersonaID]                INT          NULL,
    CONSTRAINT [PK_CfgEstatusContactoPersonal] PRIMARY KEY CLUSTERED ([CfgEstatusContactoPersonalID] ASC),
    CONSTRAINT [FK_EstatusContactoPersonal_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EstatusContactoPersonal_EstatusContactoPersonalClave]
    ON [dbo].[CfgEstatusContactoPersonal]([CfgEstatusContactoPersonalClave] ASC);

