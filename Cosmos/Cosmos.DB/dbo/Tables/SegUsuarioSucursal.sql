CREATE TABLE [dbo].[SegUsuarioSucursal] (
    [SegUsuarioSucursalID] INT IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]         INT NOT NULL,
    [PpalSucursalID]       INT NOT NULL,
    CONSTRAINT [PK_SegUsuarioSucursal] PRIMARY KEY CLUSTERED ([SegUsuarioSucursalID] ASC),
    CONSTRAINT [FK_SegUsuarioSucursal_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_SegUsuarioSucursal_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegUsuarioSucursal_SegUsuarioID_PpalSucursalID]
    ON [dbo].[SegUsuarioSucursal]([SegUsuarioID] ASC, [PpalSucursalID] ASC);

