CREATE TABLE [dbo].[PpalProveedorEmpresaSucursal] (
    [PpalProveedorEmpresaSucursalID] INT          IDENTITY (1, 1) NOT NULL,
    [PpalSucursalID]                 INT          NULL,
    [PpalProveedorID]                INT          NOT NULL,
    [PpalProveedorClave]             VARCHAR (10) NOT NULL,
    [Activo]                         BIT          NOT NULL,
    [EmpresaID]                      INT          NULL,
    CONSTRAINT [PK_ProveedorEmpresaSucursal] PRIMARY KEY CLUSTERED ([PpalProveedorEmpresaSucursalID] ASC),
    CONSTRAINT [FK_PpalProveedorEmpresaSucursal_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalProveedorEmpresaSucursal]
    ON [dbo].[PpalProveedorEmpresaSucursal]([EmpresaID] ASC, [PpalSucursalID] ASC, [PpalProveedorClave] ASC);

