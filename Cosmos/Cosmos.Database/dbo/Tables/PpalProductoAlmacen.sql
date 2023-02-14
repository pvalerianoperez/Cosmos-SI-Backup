CREATE TABLE [dbo].[PpalProductoAlmacen] (
    [PpalProductoAlmacenID] INT             IDENTITY (1, 1) NOT NULL,
    [PpalProductoID]        INT             NOT NULL,
    [PpalAlmacenID]         INT             NOT NULL,
    [Maximo]                DECIMAL (18, 2) NOT NULL,
    [Minimo]                DECIMAL (18, 2) NOT NULL,
    [Reorden]               DECIMAL (18, 2) NOT NULL,
    [CostoPromedio]         DECIMAL (18, 2) NOT NULL,
    [UltimoCosto]           DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_PpalControlProductoAlmacen] PRIMARY KEY CLUSTERED ([PpalProductoAlmacenID] ASC),
    CONSTRAINT [FK_ControlProductoAlmacen_Almacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_ProductoAlmacen_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProductoAlmacen_ProductoID_AlmacenID]
    ON [dbo].[PpalProductoAlmacen]([PpalProductoID] ASC, [PpalAlmacenID] ASC);

