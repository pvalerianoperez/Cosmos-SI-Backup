CREATE TABLE [dbo].[CmpOrdenCompraDetalle] (
    [CmpOrdenCompraDetalleID]    INT             IDENTITY (1, 1) NOT NULL,
    [CmpOrdenCompraEncabezadoID] INT             NOT NULL,
    [Renglon]                    INT             NOT NULL,
    [PpalProductoID]             INT             NOT NULL,
    [Cantidad]                   DECIMAL (18, 6) NOT NULL,
    [AuxUnidadID]                INT             NOT NULL,
    [Costo]                      DECIMAL (18, 2) NOT NULL,
    [FechaCompromiso]            DATETIME        NOT NULL,
    [DescripcionAdicional]       VARCHAR (500)   NOT NULL,
    CONSTRAINT [PK_CmpOrdenCompraDetalle] PRIMARY KEY CLUSTERED ([CmpOrdenCompraDetalleID] ASC),
    CONSTRAINT [FK_CmpOrdenCompraDetalle_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_CmpOrdenCompraDetalle_CmpOrdenCompraDetalle] FOREIGN KEY ([CmpOrdenCompraDetalleID]) REFERENCES [dbo].[CmpOrdenCompraDetalle] ([CmpOrdenCompraDetalleID]),
    CONSTRAINT [FK_CmpOrdenCompraDetalle_CmpOrdenCompraEncabezado] FOREIGN KEY ([CmpOrdenCompraEncabezadoID]) REFERENCES [dbo].[CmpOrdenCompraEncabezado] ([CmpOrdenCompraEncabezadoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CmpOrdenCompraDetalle_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpOrdenCompraDetalle_CmpOrdenCompraEncabezadoID_Renglon]
    ON [dbo].[CmpOrdenCompraDetalle]([CmpOrdenCompraEncabezadoID] ASC, [Renglon] ASC);

