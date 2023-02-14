CREATE TABLE [dbo].[PpalContactoPersonalDomicilio] (
    [PpalContactoPersonalDomicilioID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalContactoPersonalID]          INT           NOT NULL,
    [EspDomicilioID]                  INT           NOT NULL,
    [CfgTipoDomicilioID]              INT           NOT NULL,
    [Comentarios]                     VARCHAR (100) NOT NULL,
    [Predeterminado]                  BIT           NOT NULL,
    CONSTRAINT [PK_PpalContactoPersonalDomicilioID] PRIMARY KEY CLUSTERED ([PpalContactoPersonalDomicilioID] ASC),
    CONSTRAINT [FK_PpalContactoPersonalDomicilio_CfgTipoDomicilio] FOREIGN KEY ([CfgTipoDomicilioID]) REFERENCES [dbo].[CfgTipoDomicilio] ([CfgTipoDomicilioID]),
    CONSTRAINT [FK_PpalContactoPersonalDomicilio_Domicilio] FOREIGN KEY ([EspDomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID]),
    CONSTRAINT [FK_PpalContactoPersonalDomicilio_PpalContactoPersonal] FOREIGN KEY ([PpalContactoPersonalID]) REFERENCES [dbo].[PpalContactoPersonal] ([PpalContactoPersonalID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalContactoPersonalDomicilio_PpalContactoPersonalID_DomicilioID_TipoDomicilioID]
    ON [dbo].[PpalContactoPersonalDomicilio]([PpalContactoPersonalID] ASC, [EspDomicilioID] ASC, [CfgTipoDomicilioID] ASC);

