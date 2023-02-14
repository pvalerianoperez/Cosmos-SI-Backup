CREATE TABLE [dbo].[SistemaEstatusPersona] (
    [EstatusPersonaID]    INT          IDENTITY (1, 1) NOT NULL,
    [EstatusPersonaClave] VARCHAR (4)  NOT NULL,
    [Nombre]              VARCHAR (30) NOT NULL,
    [NombreCorto]         VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_SistemaEstatusPersona] PRIMARY KEY CLUSTERED ([EstatusPersonaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusPersona_EstatusPersonaClave]
    ON [dbo].[SistemaEstatusPersona]([EstatusPersonaClave] ASC);

