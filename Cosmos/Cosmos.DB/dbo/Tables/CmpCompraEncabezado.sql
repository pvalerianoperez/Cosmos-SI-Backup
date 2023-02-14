CREATE TABLE [dbo].[CmpCompraEncabezado] (
    [CmpCompraEncabezadoID]        INT           IDENTITY (1, 1) NOT NULL,
    [PpalSucursalID]               INT           NOT NULL,
    [TipoDocumentoID]              INT           NULL,
    [PpalSerieID]                  INT           NOT NULL,
    [Folio]                        INT           NOT NULL,
    [PpalProveedorID]              INT           NOT NULL,
    [CmpTipoMovimientoProveedorID] INT           NOT NULL,
    [PpalPersonalID]               INT           NOT NULL,
    [Fecha]                        DATETIME      NOT NULL,
    [Referencia]                   VARCHAR (50)  NOT NULL,
    [Concepto]                     VARCHAR (100) NOT NULL,
    [CfgEstatusDocumentoID]        INT           NOT NULL,
    [LinkXML]                      VARCHAR (250) CONSTRAINT [DF_CmpCompraEncabezado_LinkXML] DEFAULT ('') NOT NULL,
    [LinkPDF]                      VARCHAR (250) CONSTRAINT [DF_CmpCompraEncabezado_LinkPDF] DEFAULT ('') NOT NULL,
    [EstatusFactura]               CHAR (1)      CONSTRAINT [DF_CmpCompraEncabezado_EstatusFactura] DEFAULT ('N') NOT NULL,
    [PpalCentroCostoID]            INT           CONSTRAINT [DF_CmpCompraEncabezado_PpalCentroCostoID] DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoID]         INT           CONSTRAINT [DF_CmpCompraEncabezado_PpalConceptoEgresoID] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CmpCompraEncabezado] PRIMARY KEY CLUSTERED ([CmpCompraEncabezadoID] ASC),
    CONSTRAINT [FK_CmpCompraEncabezado_CfgEstatusDocumentoID] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_CmpCompraEncabezado_CmpCompraEncabezado] FOREIGN KEY ([CmpCompraEncabezadoID]) REFERENCES [dbo].[CmpCompraEncabezado] ([CmpCompraEncabezadoID]),
    CONSTRAINT [FK_CmpCompraEncabezado_CmpTipoMovimientoProveedor] FOREIGN KEY ([CmpTipoMovimientoProveedorID]) REFERENCES [dbo].[CmpTipoMovimientoProveedor] ([CmpTipoMovimientoProveedorID]),
    CONSTRAINT [FK_CmpCompraEncabezado_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpCompraEncabezado_PpalConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpCompraEncabezado_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]),
    CONSTRAINT [FK_CmpCompraEncabezado_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID]),
    CONSTRAINT [FK_CmpCompraEncabezado_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_CmpCompraEncabezado_TipoDocumentoID] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpCompraEncabezado_TipoDocumentoID_SerieID_Folio]
    ON [dbo].[CmpCompraEncabezado]([TipoDocumentoID] ASC, [PpalSerieID] ASC, [Folio] ASC);

