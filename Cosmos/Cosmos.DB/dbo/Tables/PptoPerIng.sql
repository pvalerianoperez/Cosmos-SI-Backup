CREATE TABLE [dbo].[PptoPerIng] (
    [PptoPerIngID]          INT   IDENTITY (1, 1) NOT NULL,
    [PptoDetIngID]          INT   NOT NULL,
    [CfgPeriodoOperativoID] INT   NOT NULL,
    [ImporteMeta]           MONEY NULL,
    [ImporteSolicitado]     MONEY NULL,
    [ImporteBase]           MONEY NULL,
    [ImporteEjercido]       MONEY NULL,
    CONSTRAINT [PK_PptoPerING] PRIMARY KEY CLUSTERED ([PptoPerIngID] ASC),
    CONSTRAINT [FK_PptoPerIng_CfgPeriodoOperarivo] FOREIGN KEY ([CfgPeriodoOperativoID]) REFERENCES [dbo].[CfgPeriodoOperativo] ([CfgPeriodoOperativoID]),
    CONSTRAINT [FK_PptoPerIng_PptoDetIng] FOREIGN KEY ([PptoDetIngID]) REFERENCES [dbo].[PptoDetIng] ([PptoDetIngID]) ON DELETE CASCADE
);

