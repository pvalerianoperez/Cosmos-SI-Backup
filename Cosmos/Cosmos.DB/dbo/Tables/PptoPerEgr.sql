CREATE TABLE [dbo].[PptoPerEgr] (
    [PptoPerEgrID]          INT   IDENTITY (1, 1) NOT NULL,
    [PptoDetEgrID]          INT   NOT NULL,
    [CfgPeriodoOperativoID] INT   NOT NULL,
    [ImporteMeta]           MONEY NULL,
    [ImporteSolicitado]     MONEY NULL,
    [ImporteBase]           MONEY NULL,
    [ImporteEjercido]       MONEY NULL,
    CONSTRAINT [PK_PptoPerEgr] PRIMARY KEY CLUSTERED ([PptoPerEgrID] ASC),
    CONSTRAINT [FK_PptoPerEgr_CfgPeriodoOperarivo] FOREIGN KEY ([CfgPeriodoOperativoID]) REFERENCES [dbo].[CfgPeriodoOperativo] ([CfgPeriodoOperativoID]),
    CONSTRAINT [FK_PptoPerEgr_PptoDetEgr] FOREIGN KEY ([PptoDetEgrID]) REFERENCES [dbo].[PptoDetEgr] ([PptoDetEgrID]) ON DELETE CASCADE
);

