CREATE TABLE [dbo].[BcoMovimientoBanco] (
    [BcoMovimientoBancoID] INT           NOT NULL,
    [PpalSerieID]          INT           NOT NULL,
    [Folio]                INT           NOT NULL,
    [PpalPersonalID]       INT           NOT NULL,
    [Fecha]                DATETIME      NOT NULL,
    [Referencia]           VARCHAR (50)  NOT NULL,
    [Concepto]             VARCHAR (100) NOT NULL,
    [Importe]              FLOAT (53)    NOT NULL,
    [CargoAbono]           CHAR (1)      NOT NULL,
    CONSTRAINT [PK_BcoMovimientoBanco] PRIMARY KEY CLUSTERED ([BcoMovimientoBancoID] ASC),
    CONSTRAINT [FK_BcoMovimientoBanco_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_BcoMovimientoBanco_PpalSerie] FOREIGN KEY ([PpalSerieID]) REFERENCES [dbo].[PpalSerie] ([PpalSerieID])
);

