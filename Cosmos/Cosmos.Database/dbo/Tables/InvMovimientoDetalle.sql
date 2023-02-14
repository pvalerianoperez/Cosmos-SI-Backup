CREATE TABLE [dbo].[InvMovimientoDetalle] (
    [InvMovimientoDetalleID]           INT        IDENTITY (1, 1) NOT NULL,
    [InvMovimientoEncabezadoID]        INT        NOT NULL,
    [Renglon]                          INT        NOT NULL,
    [PpalProductoID]                   INT        NOT NULL,
    [Cantidad]                         FLOAT (53) NOT NULL,
    [AuxUnidadID]                      INT        NOT NULL,
    [Costo]                            FLOAT (53) NOT NULL,
    [CantidadUnidadBase]               FLOAT (53) NOT NULL,
    [CmpOrdenCompraDetalleID]          INT        NULL,
    [CmpCompraDetalleID]               INT        NULL,
    [InvMovimientoDetalleReferenciaID] INT        NULL,
    CONSTRAINT [PK_movtos_alm_detalles] PRIMARY KEY CLUSTERED ([InvMovimientoDetalleID] ASC),
    CONSTRAINT [FK_InvMovimientoDetalle_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_InvMovimientoDetalle_CmpCompraDetalle] FOREIGN KEY ([CmpCompraDetalleID]) REFERENCES [dbo].[CmpCompraDetalle] ([CmpCompraDetalleID]),
    CONSTRAINT [FK_InvMovimientoDetalle_CmpOrdenCompraDetalle] FOREIGN KEY ([CmpOrdenCompraDetalleID]) REFERENCES [dbo].[CmpOrdenCompraDetalle] ([CmpOrdenCompraDetalleID]),
    CONSTRAINT [FK_InvMovimientoDetalle_InvMovimientoDetalle] FOREIGN KEY ([InvMovimientoEncabezadoID]) REFERENCES [dbo].[InvMovimientoEncabezado] ([InvMovimientoEncabezadoID]),
    CONSTRAINT [FK_InvMovimientoDetalle_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvMovimientoDetalle_InvmovimientoEncabezadoID_Renglon]
    ON [dbo].[InvMovimientoDetalle]([InvMovimientoEncabezadoID] ASC, [Renglon] ASC);

