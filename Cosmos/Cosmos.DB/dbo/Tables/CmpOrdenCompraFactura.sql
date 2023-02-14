CREATE TABLE [dbo].[CmpOrdenCompraFactura] (
    [CmpOrdenCompraFacturaID]    INT             IDENTITY (1, 1) NOT NULL,
    [CmpOrdenCompraEncabezadoID] INT             NOT NULL,
    [EspFacturaID]               INT             NOT NULL,
    [Importe]                    DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_CmpOrdenCompraFactura] PRIMARY KEY CLUSTERED ([CmpOrdenCompraFacturaID] ASC),
    CONSTRAINT [FK_CmpOrdenCompraFactura_CmpOrdenCompraEncabezado] FOREIGN KEY ([CmpOrdenCompraEncabezadoID]) REFERENCES [dbo].[CmpOrdenCompraEncabezado] ([CmpOrdenCompraEncabezadoID]),
    CONSTRAINT [FK_CmpOrdenCompraFactura_EspFactura] FOREIGN KEY ([EspFacturaID]) REFERENCES [dbo].[EspFactura] ([EspFacturaID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpOrdenCompraFactura_EspFacturaID_CmpOrdenCompraEncabezadoID]
    ON [dbo].[CmpOrdenCompraFactura]([EspFacturaID] ASC, [CmpOrdenCompraEncabezadoID] ASC);

