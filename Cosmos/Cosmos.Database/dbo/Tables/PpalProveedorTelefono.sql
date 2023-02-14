CREATE TABLE [dbo].[PpalProveedorTelefono] (
    [PpalProveedorTelefonoID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID]         INT           NOT NULL,
    [EspTelefonoID]           INT           NOT NULL,
    [Predeterminado]          BIT           NOT NULL,
    [Comentarios]             VARCHAR (100) NOT NULL,
    [Extension]               VARCHAR (10)  NOT NULL,
    [CfgUsoTelefonoID]        INT           NOT NULL,
    CONSTRAINT [PK_PpalProveedorTelefonoID] PRIMARY KEY CLUSTERED ([PpalProveedorTelefonoID] ASC),
    CONSTRAINT [FK_PpalProveedorTelefono_CfgUsoTelefono] FOREIGN KEY ([CfgUsoTelefonoID]) REFERENCES [dbo].[CfgUsoTelefono] ([CfgUsoTelefonoID]),
    CONSTRAINT [FK_PpalProveedorTelefono_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PpalProveedorTelefono_Telefono] FOREIGN KEY ([EspTelefonoID]) REFERENCES [dbo].[EspTelefono] ([EspTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalProveedorTelefono_PpalProveedorID_TelefonoID_Extension]
    ON [dbo].[PpalProveedorTelefono]([PpalProveedorID] ASC, [EspTelefonoID] ASC, [Extension] ASC);

