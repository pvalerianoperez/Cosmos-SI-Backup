CREATE TABLE [dbo].[PpalRepresentanteProveedorTelefono] (
    [PpalRepresentanteProveedorTelefonoID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalRepresentanteProveedorID]         INT           NOT NULL,
    [EspTelefonoID]                        INT           NOT NULL,
    [Extension]                            VARCHAR (10)  NOT NULL,
    [Predeterminado]                       BIT           NOT NULL,
    [Comentarios]                          VARCHAR (100) NOT NULL,
    [CfgUsoTelefonoID]                     INT           NOT NULL,
    CONSTRAINT [PK_PpalRepresentanteProveedorTelefonoID] PRIMARY KEY CLUSTERED ([PpalRepresentanteProveedorTelefonoID] ASC),
    CONSTRAINT [FK_PpalRepresentanteProveedorTelefono_CfgUsoTelefonoID] FOREIGN KEY ([CfgUsoTelefonoID]) REFERENCES [dbo].[CfgUsoTelefono] ([CfgUsoTelefonoID]),
    CONSTRAINT [FK_PpalRepresentanteProveedorTelefono_PpalRepresentanteProveedor] FOREIGN KEY ([PpalRepresentanteProveedorID]) REFERENCES [dbo].[PpalRepresentanteProveedor] ([PpalRepresentanteProveedorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PpalRepresentanteProveedorTelefono_Telefono] FOREIGN KEY ([EspTelefonoID]) REFERENCES [dbo].[EspTelefono] ([EspTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalRepresentanteProveedorTelefono_PpalRepresentanteProveedorID_TelefonoID_Extension]
    ON [dbo].[PpalRepresentanteProveedorTelefono]([PpalRepresentanteProveedorID] ASC, [EspTelefonoID] ASC, [Extension] ASC);

