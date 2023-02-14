CREATE TABLE [dbo].[CoPartidaDetalle] (
    [CoPartidaDetalleID]    INT             IDENTITY (1, 1) NOT NULL,
    [CoPartidaID]           INT             NOT NULL,
    [PpalProductoID]        INT             NOT NULL,
    [Cantidad]              DECIMAL (18, 6) NOT NULL,
    [Precio]                DECIMAL (18, 6) NOT NULL,
    [AuxUnidadID]           INT             NOT NULL,
    [Adicional]             VARCHAR (500)   NOT NULL,
    [Observaciones]         VARCHAR (500)   NOT NULL,
    [PpalAreaID]            INT             DEFAULT ((0)) NOT NULL,
    [SustituirConAdicional] BIT             DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoID]  INT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CoPartidaDetalle] PRIMARY KEY CLUSTERED ([CoPartidaDetalleID] ASC),
    CONSTRAINT [FK_CoPartidaDetalle_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_CoPartidaDetalle_CoPartida] FOREIGN KEY ([CoPartidaID]) REFERENCES [dbo].[CoPartida] ([CoPartidaID]),
    CONSTRAINT [FK_CoPartidaDetalle_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_CoPartidaDetalle_PpalProducto] FOREIGN KEY ([PpalProductoID]) REFERENCES [dbo].[PpalProducto] ([PpalProductoID])
);

