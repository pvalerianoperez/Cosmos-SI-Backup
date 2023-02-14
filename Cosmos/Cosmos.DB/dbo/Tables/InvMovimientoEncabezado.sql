CREATE TABLE [dbo].[InvMovimientoEncabezado] (
    [InvMovimientoEncabezadoID]     INT           IDENTITY (1, 1) NOT NULL,
    [PpalSucursalID]                INT           NOT NULL,
    [TipoDocumentoID]               INT           NOT NULL,
    [PpalSerieID]                   INT           NOT NULL,
    [Folio]                         INT           NOT NULL,
    [InvTipoMovimientoInventarioID] INT           NOT NULL,
    [PpalPersonalID]                INT           NOT NULL,
    [Fecha]                         DATETIME      NOT NULL,
    [Referencia]                    VARCHAR (50)  NOT NULL,
    [Concepto]                      VARCHAR (100) NOT NULL,
    [CfgEstatusDocumentoID]         INT           NOT NULL,
    CONSTRAINT [PK_InvMovtoEncabezado] PRIMARY KEY CLUSTERED ([InvMovimientoEncabezadoID] ASC),
    CONSTRAINT [FK_InvMovimientoEncabezado_CfgEstatusDocumento] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_InvMovimientoEncabezado_InvTipoMovimientoInventario] FOREIGN KEY ([InvTipoMovimientoInventarioID]) REFERENCES [dbo].[InvTipoMovimientoInventario] ([InvTipoMovimientoInventarioID]),
    CONSTRAINT [FK_InvMovimientoEncabezado_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_InvMovimientoEncabezado_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID]),
    CONSTRAINT [FK_InvMovimientoEncabezado_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_InvMovimientoEncabezado_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvMovimientoEncabezado_PpalSucursalID_TipoDocumentoID_PpalSerieID_Folio]
    ON [dbo].[InvMovimientoEncabezado]([PpalSucursalID] ASC, [TipoDocumentoID] ASC, [PpalSerieID] ASC, [Folio] ASC);

