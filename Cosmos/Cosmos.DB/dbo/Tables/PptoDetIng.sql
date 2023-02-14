CREATE TABLE [dbo].[PptoDetIng] (
    [PptoDetIngID]          INT IDENTITY (1, 1) NOT NULL,
    [PptoEncIngID]          INT NOT NULL,
    [PpalConceptoIngresoID] INT NOT NULL,
    [PpalCuentaContableID]  INT NOT NULL,
    [RubroContableID]       INT NOT NULL,
    CONSTRAINT [PK_PptoDetIng] PRIMARY KEY CLUSTERED ([PptoDetIngID] ASC),
    CONSTRAINT [FK_PptoDetIng_ConceptoIngreso] FOREIGN KEY ([PpalConceptoIngresoID]) REFERENCES [dbo].[PpalConceptoIngreso] ([PpalConceptoIngresoID]),
    CONSTRAINT [FK_PptoDetIng_CuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_PptoDetIng_PptoEncIng] FOREIGN KEY ([PptoEncIngID]) REFERENCES [dbo].[PptoEncIng] ([PptoEncIngID]),
    CONSTRAINT [FK_PptoDetIng_RubroContable] FOREIGN KEY ([RubroContableID]) REFERENCES [dbo].[RubroContable] ([RubroContableID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDetIng]
    ON [dbo].[PptoDetIng]([PptoEncIngID] ASC, [RubroContableID] ASC, [PpalConceptoIngresoID] ASC);

