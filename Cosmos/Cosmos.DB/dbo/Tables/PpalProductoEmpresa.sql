CREATE TABLE [dbo].[PpalProductoEmpresa] (
    [PpalProductoEmpresaID] INT          IDENTITY (1, 1) NOT NULL,
    [EmpresaID]             INT          NOT NULL,
    [PpalProductoID]        INT          NOT NULL,
    [ProductoClave]         VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_PpalProductoEmpresa] PRIMARY KEY CLUSTERED ([PpalProductoEmpresaID] ASC),
    CONSTRAINT [FK_ProductoEmpresa_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID]),
    CONSTRAINT [FK_ProductoEmpresa_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);

