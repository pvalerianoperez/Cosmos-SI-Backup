CREATE TABLE [dbo].[CmpRequisicionEncabezado] (
    [CmpRequisicionEncabezadoID] INT           IDENTITY (1, 1) NOT NULL,
    [TipoDocumentoID]            INT           NOT NULL,
    [PpalSerieID]                INT           NOT NULL,
    [PpalSucursalID]             INT           NOT NULL,
    [Folio]                      INT           NOT NULL,
    [Fecha]                      DATETIME      NOT NULL,
    [Referencia]                 VARCHAR (50)  NOT NULL,
    [PpalPersonalID]             INT           NOT NULL,
    [PpalCentroCostoID]          INT           NOT NULL,
    [PpalAreaID]                 INT           NOT NULL,
    [Concepto]                   VARCHAR (100) NOT NULL,
    [CfgEstatusDocumentoID]      INT           NOT NULL,
    [ExplosionID]                INT           NOT NULL,
    CONSTRAINT [PK_CmpRequisicionEncabezado] PRIMARY KEY CLUSTERED ([CmpRequisicionEncabezadoID] ASC),
    CONSTRAINT [FK_CmpRequisicionEncabezado_CfgEstatusDocumento] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_CmpRequisicionEncabezado_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpRequisicionEncabezado_TipoDocumentoID_SerieID_Folio]
    ON [dbo].[CmpRequisicionEncabezado]([TipoDocumentoID] ASC, [PpalSerieID] ASC, [Folio] ASC);

