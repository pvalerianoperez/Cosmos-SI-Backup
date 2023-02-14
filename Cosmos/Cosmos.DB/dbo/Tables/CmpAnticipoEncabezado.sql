CREATE TABLE [dbo].[CmpAnticipoEncabezado] (
    [CmpAnticipoEncabezadoID]      INT           NOT NULL,
    [PpalSucursalID]               INT           NOT NULL,
    [TipoDocumentoID]              INT           NOT NULL,
    [PpalSerieID]                  INT           NOT NULL,
    [Folio]                        INT           NOT NULL,
    [PpalProveedorID]              INT           NOT NULL,
    [CmpTipoMovimientoProveedorID] INT           NOT NULL,
    [PpalPersonalID]               INT           NOT NULL,
    [Fecha]                        DATETIME      NOT NULL,
    [Referencia]                   VARCHAR (50)  NOT NULL,
    [Concepto]                     VARCHAR (100) NOT NULL,
    [Importe]                      FLOAT (53)    NOT NULL,
    [BcoMovimientoID]              INT           NOT NULL,
    CONSTRAINT [PK_CmpAnticipoEncabezado] PRIMARY KEY CLUSTERED ([CmpAnticipoEncabezadoID] ASC),
    CONSTRAINT [FK_CmpAnticipoEncabezado_CmpTipoMovimientoProveedor] FOREIGN KEY ([CmpTipoMovimientoProveedorID]) REFERENCES [dbo].[CmpTipoMovimientoProveedor] ([CmpTipoMovimientoProveedorID]),
    CONSTRAINT [FK_CmpAnticipoEncabezado_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_CmpAnticipoEncabezado_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]),
    CONSTRAINT [FK_CmpAnticipoEncabezado_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID]),
    CONSTRAINT [FK_CmpAnticipoEncabezado_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_CmpAnticipoEncabezado_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalSucursalID_TipoDocumentoID_PpalSerieID_Folio]
    ON [dbo].[CmpAnticipoEncabezado]([PpalSucursalID] ASC, [TipoDocumentoID] ASC, [PpalSerieID] ASC, [Folio] ASC);

