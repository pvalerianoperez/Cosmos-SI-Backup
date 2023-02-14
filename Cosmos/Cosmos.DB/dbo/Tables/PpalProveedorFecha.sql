CREATE TABLE [dbo].[PpalProveedorFecha] (
    [PpalProveedorFechaID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID]      INT           NOT NULL,
    [Fecha]                DATE          NOT NULL,
    [CfgTipoFechaID]       INT           NOT NULL,
    [Comentarios]          VARCHAR (100) NOT NULL,
    [Predeterminado]       BIT           NOT NULL,
    CONSTRAINT [PK_PpalProveedorFechaID] PRIMARY KEY CLUSTERED ([PpalProveedorFechaID] ASC),
    CONSTRAINT [FK_PpalProveedorFecha_CfgTipoFecha] FOREIGN KEY ([CfgTipoFechaID]) REFERENCES [dbo].[CfgTipoFecha] ([CfgTipoFechaID]),
    CONSTRAINT [FK_PpalProveedorFecha_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PpalProveedorFecha_PpalProveedorID_TipoFechaID_Fecha]
    ON [dbo].[PpalProveedorFecha]([PpalProveedorID] ASC, [CfgTipoFechaID] ASC, [Fecha] ASC);

