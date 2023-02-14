CREATE TABLE [dbo].[CmpMovimientoProveedor] (
    [CmpMovimientoProveedorID]     INT           NOT NULL,
    [CmpCompraEncabezadoID]        INT           NOT NULL,
    [TipoDocumentoID]              INT           NOT NULL,
    [PpalSerieID]                  INT           NOT NULL,
    [Folio]                        INT           NOT NULL,
    [PpalPersonalID]               INT           NOT NULL,
    [Fecha]                        DATETIME      NOT NULL,
    [Referencia]                   VARCHAR (50)  NOT NULL,
    [Concepto]                     VARCHAR (100) NOT NULL,
    [Importe]                      FLOAT (53)    NOT NULL,
    [CmpTipoMovimientoProveedorID] INT           NOT NULL,
    [BcoMovimientoID]              INT           NOT NULL,
    CONSTRAINT [PK_CmpMovimientoProveedor] PRIMARY KEY CLUSTERED ([CmpMovimientoProveedorID] ASC)
);

