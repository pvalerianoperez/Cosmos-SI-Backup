CREATE TABLE [dbo].[CmpCompraPago] (
    [CmpCompraPagoID]       INT             IDENTITY (1, 1) NOT NULL,
    [CmpCompraEncabezadoID] INT             NOT NULL,
    [BcoMovimientoID]       INT             NOT NULL,
    [Importe]               DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_CmpCompraPago] PRIMARY KEY CLUSTERED ([CmpCompraPagoID] ASC),
    CONSTRAINT [FK_CmpCompraPago_BcoMovimiento] FOREIGN KEY ([BcoMovimientoID]) REFERENCES [dbo].[BcoMovimiento] ([BcoMovimientoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CmpCompraPago_CmpCompraEncabezado] FOREIGN KEY ([CmpCompraEncabezadoID]) REFERENCES [dbo].[CmpCompraEncabezado] ([CmpCompraEncabezadoID])
);

