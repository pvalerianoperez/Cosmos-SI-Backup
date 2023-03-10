CREATE TABLE [dbo].[InvMovimientoDesglose] (
    [InvMovimientoDesgloseID]           INT        IDENTITY (1, 1) NOT NULL,
    [InvMovimientoDetalleID]            INT        NOT NULL,
    [Renglon]                           INT        NOT NULL,
    [CmpRequisicionDetalleID]           INT        NULL,
    [CmpOrdenCompraDesgloseID]          INT        NULL,
    [CmpCompraDesgloseID]               INT        NULL,
    [PpalSucursalID]                    INT        NOT NULL,
    [PpalCentroCostoID]                 INT        NOT NULL,
    [PpalAreaID]                        INT        NOT NULL,
    [PpalAlmacenID]                     INT        NOT NULL,
    [PpalConceptoEgresoID]              INT        NOT NULL,
    [PpalCuentaContableID]              INT        NOT NULL,
    [cantidad]                          FLOAT (53) NOT NULL,
    [InvMovimientoDesgloseReferenciaID] INT        NULL,
    CONSTRAINT [PK_InvMovimientosDesglose] PRIMARY KEY CLUSTERED ([InvMovimientoDesgloseID] ASC),
    CONSTRAINT [FK_InvMovimientoDesglose_InvMovimientoDetalle] FOREIGN KEY ([InvMovimientoDetalleID]) REFERENCES [dbo].[InvMovimientoDetalle] ([InvMovimientoDetalleID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalAlmacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalCuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_InvMovimientoDesglose_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID])
);

