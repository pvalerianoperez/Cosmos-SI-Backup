CREATE TABLE [dbo].[CoContratista] (
    [CoContratistaID] INT IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID] INT NOT NULL,
    CONSTRAINT [PK_CoContratista] PRIMARY KEY CLUSTERED ([CoContratistaID] ASC),
    CONSTRAINT [FK_CoContratista_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoContratista_PpalProveedorID]
    ON [dbo].[CoContratista]([PpalProveedorID] ASC);

