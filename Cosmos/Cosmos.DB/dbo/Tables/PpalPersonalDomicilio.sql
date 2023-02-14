CREATE TABLE [dbo].[PpalPersonalDomicilio] (
    [PpalPersonalDomicilioID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalPersonalID]          INT           NOT NULL,
    [EspDomicilioID]          INT           NOT NULL,
    [CfgTipoDomicilioID]      INT           NOT NULL,
    [Comentarios]             VARCHAR (100) NOT NULL,
    [Predeterminado]          BIT           NOT NULL,
    CONSTRAINT [PK_PersonalDomicilio] PRIMARY KEY CLUSTERED ([PpalPersonalDomicilioID] ASC),
    CONSTRAINT [FK_PersonalDomicilio_CfgTipoDomicilio] FOREIGN KEY ([CfgTipoDomicilioID]) REFERENCES [dbo].[CfgTipoDomicilio] ([CfgTipoDomicilioID]),
    CONSTRAINT [FK_PersonalDomicilio_Domicilio] FOREIGN KEY ([EspDomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PersonalDomicilio_PersonalID_DomicilioID_TipoDomicilioID]
    ON [dbo].[PpalPersonalDomicilio]([PpalPersonalID] ASC, [EspDomicilioID] ASC, [CfgTipoDomicilioID] ASC);

