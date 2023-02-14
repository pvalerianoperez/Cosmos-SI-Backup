CREATE TABLE [dbo].[CmpOrdenCompraDesglose] (
    [CmpOrdenCompraDesgloseID] INT           IDENTITY (1, 1) NOT NULL,
    [CmpOrdenCompraDetalleID]  INT           NOT NULL,
    [Renglon]                  INT           NOT NULL,
    [PpalSucursalID]           INT           NOT NULL,
    [PpalCentroCostoID]        INT           NOT NULL,
    [PpalAreaID]               INT           NOT NULL,
    [PpalAlmacenID]            INT           NOT NULL,
    [ConceptoEgresoID]         INT           NOT NULL,
    [PpalCuentaContableID]     INT           NOT NULL,
    [Cantidad]                 FLOAT (53)    NOT NULL,
    [CmpRequisicionDetalleID]  INT           NULL,
    [DescripcionAdicional]     VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_CmpOrdenCompraDesglose] PRIMARY KEY CLUSTERED ([CmpOrdenCompraDesgloseID] ASC),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_Almacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_CmpOrdenCompraDetalle] FOREIGN KEY ([CmpOrdenCompraDetalleID]) REFERENCES [dbo].[CmpOrdenCompraDetalle] ([CmpOrdenCompraDetalleID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_CmpRequisicionDetalle] FOREIGN KEY ([CmpRequisicionDetalleID]) REFERENCES [dbo].[CmpRequisicionDetalle] ([CmpRequisicionDetalleID]) ON DELETE SET NULL,
    CONSTRAINT [FK_CmpOrdenCompraDesglose_ConceptoEgreso] FOREIGN KEY ([ConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_PpalCuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_CmpOrdenCompraDesglose_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpOrdenCompraDesglose_CmpOrdenCompraDetalleID_Renglon]
    ON [dbo].[CmpOrdenCompraDesglose]([CmpOrdenCompraDetalleID] ASC, [Renglon] ASC);

