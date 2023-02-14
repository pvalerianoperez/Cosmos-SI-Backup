CREATE TABLE [dbo].[CmpAnticipoDetalle] (
    [CmpAnticipoDetalleID]    INT           NOT NULL,
    [CmpAnticipoEncabezadoID] INT           NOT NULL,
    [PpalCentroCostoID]       INT           NOT NULL,
    [PpalAreaID]              INT           NOT NULL,
    [PpalConceptoEgresoID]    INT           NOT NULL,
    [PpalCuentaContableID]    INT           NOT NULL,
    [Importe]                 FLOAT (53)    NOT NULL,
    [Descripcion]             VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_CmdAnticipoDetalle] PRIMARY KEY CLUSTERED ([CmpAnticipoDetalleID] ASC),
    CONSTRAINT [FK_CmpAnticipoDetalle_CmpAnticipoEncabezado] FOREIGN KEY ([CmpAnticipoEncabezadoID]) REFERENCES [dbo].[CmpAnticipoEncabezado] ([CmpAnticipoEncabezadoID]),
    CONSTRAINT [FK_CmpAnticipoDetalle_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CmpAnticipoDetalle_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpAnticipoDetalle_PpalConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpAnticipoDetalle_PpalCuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID])
);

