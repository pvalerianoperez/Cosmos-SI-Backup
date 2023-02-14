CREATE TABLE [dbo].[CfgTasaIVA] (
    [CfgTasaIVAID]    INT            IDENTITY (1, 1) NOT NULL,
    [CfgTasaIVAClave] VARCHAR (3)    NOT NULL,
    [Nombre]          VARCHAR (30)   NOT NULL,
    [NombreCorto]     VARCHAR (8)    NOT NULL,
    [PorcentajeIVA]   DECIMAL (5, 2) CONSTRAINT [DF_CfgTasaIVA_PorcentajeIVA] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CfgTasaIVA] PRIMARY KEY CLUSTERED ([CfgTasaIVAID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgTasaIVA]
    ON [dbo].[CfgTasaIVA]([CfgTasaIVAClave] ASC);

