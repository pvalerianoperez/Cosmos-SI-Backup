CREATE TABLE [dbo].[PptoEncIng] (
    [PptoEncIngID]         INT          IDENTITY (1, 1) NOT NULL,
    [PpalCentroCostoID]    INT          NOT NULL,
    [EstatusDocumentoID]   VARCHAR (10) NOT NULL,
    [PpalCuentaContableID] INT          NOT NULL,
    CONSTRAINT [PK_PptoEncIng] PRIMARY KEY CLUSTERED ([PptoEncIngID] ASC),
    CONSTRAINT [FK_PptoEncIng_CuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_PptoEncIng_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID])
);

