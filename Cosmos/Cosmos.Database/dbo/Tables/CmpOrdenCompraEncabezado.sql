CREATE TABLE [dbo].[CmpOrdenCompraEncabezado] (
    [CmpOrdenCompraEncabezadoID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalSucursalID]             INT           NOT NULL,
    [TipoDocumentoID]            INT           NOT NULL,
    [PpalSerieID]                INT           NOT NULL,
    [Folio]                      INT           NOT NULL,
    [PpalProveedorID]            INT           NOT NULL,
    [PpalPersonalID]             INT           NOT NULL,
    [Fecha]                      DATETIME      NOT NULL,
    [Referencia]                 VARCHAR (50)  NOT NULL,
    [Concepto]                   VARCHAR (100) NOT NULL,
    [CfgEstatusDocumentoID]      INT           NOT NULL,
    [LinkXML]                    VARCHAR (250) CONSTRAINT [DF_CmpOrdenCompraEncabezado_LinkXML] DEFAULT ('') NOT NULL,
    [LinkPDF]                    VARCHAR (250) CONSTRAINT [DF_CmpOrdenCompraEncabezado_LinkPDF] DEFAULT ('') NOT NULL,
    [EstatusFactura]             CHAR (1)      CONSTRAINT [DF_CmpOrdenCompraEncabezado_EstatusFactura] DEFAULT ('N') NOT NULL,
    [PpalCentroCostoID]          INT           CONSTRAINT [DF_CmpOrdenCompraEncabezado_PpalCentroCostoID] DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoID]       INT           CONSTRAINT [DF_CmpOrdenCompraEncabezado_PpalConceptoEgresoID] DEFAULT ((0)) NOT NULL,
    [PpalAreaID]                 INT           NULL,
    CONSTRAINT [PK_CmpOrdenCompraEncabezado] PRIMARY KEY CLUSTERED ([CmpOrdenCompraEncabezadoID] ASC),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_CfgEstatusDocumento] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_CmpOrdenCompraEncabezado_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpOrdenCompraEncabezado_TipoDocumentoID_SerieID_Folio]
    ON [dbo].[CmpOrdenCompraEncabezado]([TipoDocumentoID] ASC, [PpalSerieID] ASC, [Folio] ASC);

