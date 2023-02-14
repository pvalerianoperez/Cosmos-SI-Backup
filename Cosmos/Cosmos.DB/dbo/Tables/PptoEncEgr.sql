CREATE TABLE [dbo].[PptoEncEgr] (
    [PptoEncEgrID]         INT          IDENTITY (1, 1) NOT NULL,
    [PpalCentroCostoID]    INT          NOT NULL,
    [EstatusDocumentoID]   VARCHAR (10) NOT NULL,
    [PpalCuentaContableID] INT          NOT NULL,
    CONSTRAINT [PK_PptoEncEgr] PRIMARY KEY CLUSTERED ([PptoEncEgrID] ASC),
    CONSTRAINT [FK_PptoEncEgr_CuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_PptoEncEgr_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoEncEgr]
    ON [dbo].[PptoEncEgr]([PpalCentroCostoID] ASC);

