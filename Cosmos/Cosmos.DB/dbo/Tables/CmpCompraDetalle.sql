CREATE TABLE [dbo].[CmpCompraDetalle] (
    [CmpCompraDetalleID]    INT             IDENTITY (1, 1) NOT NULL,
    [CmpCompraEncabezadoID] INT             NOT NULL,
    [Renglon]               INT             NOT NULL,
    [PpalProductoID]        INT             NOT NULL,
    [Cantidad]              DECIMAL (18, 6) NOT NULL,
    [AuxUnidadID]           INT             NOT NULL,
    [Costo]                 DECIMAL (18, 2) NOT NULL,
    [DescripcionAdicional]  VARCHAR (500)   NOT NULL,
    CONSTRAINT [PK_CmpCompraDetalle] PRIMARY KEY CLUSTERED ([CmpCompraDetalleID] ASC),
    CONSTRAINT [FK_CmpCompraDetalle_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_CmpCompraDetalle_CmpCompraEncabezado] FOREIGN KEY ([CmpCompraEncabezadoID]) REFERENCES [dbo].[CmpCompraEncabezado] ([CmpCompraEncabezadoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CmpCompraDetalle_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompraDetalle_CompraEncabezadoID_Renglon]
    ON [dbo].[CmpCompraDetalle]([CmpCompraEncabezadoID] ASC, [Renglon] ASC);

