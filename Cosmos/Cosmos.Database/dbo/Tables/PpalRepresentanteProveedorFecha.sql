CREATE TABLE [dbo].[PpalRepresentanteProveedorFecha] (
    [PpalRepresentanteProveedorFechaID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalRepresentanteProveedorID]      INT           NOT NULL,
    [Fecha]                             DATE          NOT NULL,
    [CfgTipoFechaID]                    INT           NOT NULL,
    [Comentarios]                       VARCHAR (100) NOT NULL,
    [Predeterminado]                    BIT           NOT NULL,
    CONSTRAINT [PK_PpalRepresentanteProveedorFechaID] PRIMARY KEY CLUSTERED ([PpalRepresentanteProveedorFechaID] ASC),
    CONSTRAINT [FK_PpalRepresentanteProveedorFecha_CfgTipoFecha] FOREIGN KEY ([CfgTipoFechaID]) REFERENCES [dbo].[CfgTipoFecha] ([CfgTipoFechaID]),
    CONSTRAINT [FK_PpalRepresentanteProveedorFecha_PpalRepresentanteProveedor] FOREIGN KEY ([PpalRepresentanteProveedorID]) REFERENCES [dbo].[PpalRepresentanteProveedor] ([PpalRepresentanteProveedorID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalRepresentanteProveedorFecha_PpalRepresentanteProveedorID_TipoFechaID_Fecha]
    ON [dbo].[PpalRepresentanteProveedorFecha]([PpalRepresentanteProveedorID] ASC, [CfgTipoFechaID] ASC, [Fecha] ASC);

