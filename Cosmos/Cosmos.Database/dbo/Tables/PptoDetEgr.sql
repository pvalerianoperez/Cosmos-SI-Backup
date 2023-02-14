CREATE TABLE [dbo].[PptoDetEgr] (
    [PptoDetEgrID]         INT IDENTITY (1, 1) NOT NULL,
    [PptoEncEgrID]         INT NOT NULL,
    [ConceptoEgresoID]     INT NOT NULL,
    [PpalCuentaContableID] INT NOT NULL,
    [RubroContableID]      INT NOT NULL,
    CONSTRAINT [PK_PptoDetEgr] PRIMARY KEY CLUSTERED ([PptoDetEgrID] ASC),
    CONSTRAINT [FK_PptoDetEgr_ConceptoEgreso] FOREIGN KEY ([ConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_PptoDetEgr_CuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_PptoDetEgr_PptoEncEgr] FOREIGN KEY ([PptoEncEgrID]) REFERENCES [dbo].[PptoEncEgr] ([PptoEncEgrID]),
    CONSTRAINT [FK_PptoDetEgr_RubroContable] FOREIGN KEY ([RubroContableID]) REFERENCES [dbo].[RubroContable] ([RubroContableID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDetEgr]
    ON [dbo].[PptoDetEgr]([PptoEncEgrID] ASC, [RubroContableID] ASC, [ConceptoEgresoID] ASC);

