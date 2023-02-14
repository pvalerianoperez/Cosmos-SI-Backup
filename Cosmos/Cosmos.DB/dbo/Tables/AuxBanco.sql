CREATE TABLE [dbo].[AuxBanco] (
    [AuxBancoID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxBancoClave] VARCHAR (4)  NOT NULL,
    [Nombre]        VARCHAR (30) NOT NULL,
    [NombreCorto]   VARCHAR (10) NULL,
    CONSTRAINT [PK_AuxBanco] PRIMARY KEY CLUSTERED ([AuxBancoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Banco_BancoClave]
    ON [dbo].[AuxBanco]([AuxBancoClave] ASC);

