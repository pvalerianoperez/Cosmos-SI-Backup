CREATE TABLE [dbo].[PpalProveedorDomicilio] (
    [PpalProveedorDomicilioID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID]          INT           NOT NULL,
    [EspDomicilioID]           INT           NOT NULL,
    [Comentario]               VARCHAR (100) NOT NULL,
    [Predeterminado]           BIT           NOT NULL,
    [CfgTipoDomicilioID]       INT           NOT NULL,
    CONSTRAINT [PK_PpalProveedorDomicilioID] PRIMARY KEY CLUSTERED ([PpalProveedorDomicilioID] ASC),
    CONSTRAINT [FK_PpalProveedorDomicilio_CfgTipoDomicilio] FOREIGN KEY ([CfgTipoDomicilioID]) REFERENCES [dbo].[CfgTipoDomicilio] ([CfgTipoDomicilioID]),
    CONSTRAINT [FK_PpalProveedorDomicilio_Domicilio] FOREIGN KEY ([EspDomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID]),
    CONSTRAINT [FK_ProveedorDomicilio_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProveedorDomicilio_ProveedorID_DomicilioID_TipoDomicilioID]
    ON [dbo].[PpalProveedorDomicilio]([PpalProveedorID] ASC, [EspDomicilioID] ASC, [CfgTipoDomicilioID] ASC);

