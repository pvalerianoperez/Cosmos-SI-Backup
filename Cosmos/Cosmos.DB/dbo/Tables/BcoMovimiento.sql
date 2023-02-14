CREATE TABLE [dbo].[BcoMovimiento] (
    [BcoMovimientoID]     INT             IDENTITY (1, 1) NOT NULL,
    [PpalSerieID]         INT             NOT NULL,
    [Folio]               INT             NOT NULL,
    [PpalPersonalID]      INT             NOT NULL,
    [Fecha]               DATETIME        NOT NULL,
    [Referencia]          VARCHAR (50)    NOT NULL,
    [Concepto]            VARCHAR (100)   NOT NULL,
    [Importe]             DECIMAL (18, 2) NULL,
    [BcoTipoMovimientoID] INT             NOT NULL,
    [BcoCuentaID]         INT             NOT NULL,
    [AuxFormaPagoID]      INT             NOT NULL,
    CONSTRAINT [PK_BcoMovimiento] PRIMARY KEY CLUSTERED ([BcoMovimientoID] ASC),
    CONSTRAINT [FK_BcoMovimiento_AuxFormaPago] FOREIGN KEY ([AuxFormaPagoID]) REFERENCES [dbo].[AuxFormaPago] ([AuxFormaPagoID]),
    CONSTRAINT [FK_BcoMovimiento_BcoCuenta] FOREIGN KEY ([BcoCuentaID]) REFERENCES [dbo].[BcoCuenta] ([BcoCuentaID]),
    CONSTRAINT [FK_BcoMovimiento_BcoTipoMovimiento] FOREIGN KEY ([BcoTipoMovimientoID]) REFERENCES [dbo].[BcoTipoMovimiento] ([BcoTipoMovimientoID]),
    CONSTRAINT [FK_BcoMovimiento_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_BcoMovimiento_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID])
);

