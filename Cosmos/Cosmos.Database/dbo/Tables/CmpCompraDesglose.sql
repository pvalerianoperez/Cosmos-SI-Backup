CREATE TABLE [dbo].[CmpCompraDesglose] (
    [CmpCompraDesgloseID]      INT           IDENTITY (1, 1) NOT NULL,
    [CmpCompraDetalleID]       INT           NOT NULL,
    [Renglon]                  INT           NOT NULL,
    [PpalSucursalID]           INT           NOT NULL,
    [PpalCentroCostoID]        INT           NOT NULL,
    [PpalAreaID]               INT           NOT NULL,
    [PpalAlmacenID]            INT           NOT NULL,
    [PpalConceptoEgresoID]     INT           NOT NULL,
    [PpalCuentaContableID]     INT           NOT NULL,
    [Cantidad]                 FLOAT (53)    NOT NULL,
    [CmpOrdenCompraDesgloseID] INT           NULL,
    [DescripcionAdicional]     VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_CmpCompraDesglose] PRIMARY KEY CLUSTERED ([CmpCompraDesgloseID] ASC),
    CONSTRAINT [FK_CmpCompraDesglose_Almacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_CmpCompraDesglose_CmpCompraDetalle] FOREIGN KEY ([CmpCompraDetalleID]) REFERENCES [dbo].[CmpCompraDetalle] ([CmpCompraDetalleID]),
    CONSTRAINT [FK_CmpCompraDesglose_CmpOrdenCompraDesglose] FOREIGN KEY ([CmpOrdenCompraDesgloseID]) REFERENCES [dbo].[CmpOrdenCompraDesglose] ([CmpOrdenCompraDesgloseID]) ON DELETE SET NULL,
    CONSTRAINT [FK_CmpCompraDesglose_ConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpCompraDesglose_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CmpCompraDesglose_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpCompraDesglose_PpalCuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_CmpCompraDesglose_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompraDesglose_CompraDetalleID_Renglon]
    ON [dbo].[CmpCompraDesglose]([CmpCompraDetalleID] ASC, [Renglon] ASC);

