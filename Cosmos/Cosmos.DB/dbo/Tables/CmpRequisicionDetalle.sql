CREATE TABLE [dbo].[CmpRequisicionDetalle] (
    [CmpRequisicionDetalleID]    INT             IDENTITY (1, 1) NOT NULL,
    [CmpRequisicionEncabezadoID] INT             NOT NULL,
    [Renglon]                    INT             NOT NULL,
    [PpalProductoID]             INT             NOT NULL,
    [Cantidad]                   DECIMAL (18, 6) NOT NULL,
    [AuxUnidadID]                INT             NOT NULL,
    [PpalAlmacenID]              INT             NOT NULL,
    [PpalConceptoEgresoID]       INT             NOT NULL,
    [PpalCuentaContableID]       INT             NOT NULL,
    [DescripcionAdicional]       VARCHAR (500)   NOT NULL,
    [CfgEstatusDocumentoID]      INT             NOT NULL,
    CONSTRAINT [PK_CmpRequisicionDetalle] PRIMARY KEY CLUSTERED ([CmpRequisicionDetalleID] ASC),
    CONSTRAINT [FK_CmpRequisicionDetalle_Almacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_CfgEstatusDocumento] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_CmpRequisicionDetalle] FOREIGN KEY ([CmpRequisicionDetalleID]) REFERENCES [dbo].[CmpRequisicionDetalle] ([CmpRequisicionDetalleID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_CmpRequisicionEncabezado] FOREIGN KEY ([CmpRequisicionEncabezadoID]) REFERENCES [dbo].[CmpRequisicionEncabezado] ([CmpRequisicionEncabezadoID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_ConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_PpalCuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_CmpRequisicionDetalle_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpRequisicionDetalle_CmpRequisicionEncabezadoID_Renglon]
    ON [dbo].[CmpRequisicionDetalle]([CmpRequisicionEncabezadoID] ASC, [Renglon] ASC);

