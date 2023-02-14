CREATE TABLE [dbo].[PpalAlmacen] (
    [PpalAlmacenID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalAlmacenClave] VARCHAR (20) NOT NULL,
    [Nombre]           VARCHAR (50) NOT NULL,
    [NombreCorto]      VARCHAR (20) NOT NULL,
    [PpalSucursalID]   INT          NOT NULL,
    [Activo] BIT NOT NULL, 
    CONSTRAINT [PK_PpalAlmacen] PRIMARY KEY CLUSTERED ([PpalAlmacenID] ASC),
    CONSTRAINT [FK_Almacen_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Almacen_SucursalID_AlmacenClave]
    ON [dbo].[PpalAlmacen]([PpalSucursalID] ASC, [PpalAlmacenClave] ASC);

