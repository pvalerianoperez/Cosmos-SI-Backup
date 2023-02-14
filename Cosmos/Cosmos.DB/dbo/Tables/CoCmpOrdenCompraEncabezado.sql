CREATE TABLE [dbo].[CoCmpOrdenCompraEncabezado] (
    [CmpOrdenCompraEncabezadoID] INT NOT NULL,
    [CoPartidaID]                INT NOT NULL,
    CONSTRAINT [PK_CoCmpOrdenCompraEncabezado] PRIMARY KEY CLUSTERED ([CmpOrdenCompraEncabezadoID] ASC),
    CONSTRAINT [FK_CoCmpOrdenCompraEncabezado_CmpOrdenCompraEncabezado] FOREIGN KEY ([CmpOrdenCompraEncabezadoID]) REFERENCES [dbo].[CmpOrdenCompraEncabezado] ([CmpOrdenCompraEncabezadoID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CoCmpOrdenCompraEncabezado_CoPartida] FOREIGN KEY ([CoPartidaID]) REFERENCES [dbo].[CoPartida] ([CoPartidaID])
);

