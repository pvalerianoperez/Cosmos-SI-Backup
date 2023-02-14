CREATE TABLE [dbo].[CfgEstatusPersonal] (
    [CfgEstatusPersonalID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgEstatusPersonalClave] VARCHAR (6)  NOT NULL,
    [Nombre]                  VARCHAR (30) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    [EstatusPersonaID]        INT          NOT NULL,
    CONSTRAINT [PK_CfgEstatusPersonal] PRIMARY KEY CLUSTERED ([CfgEstatusPersonalID] ASC),
    CONSTRAINT [FK_EstatusPersonal_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EstatusPersonal_EstatusPersonalClave]
    ON [dbo].[CfgEstatusPersonal]([CfgEstatusPersonalClave] ASC);

