CREATE TABLE [dbo].[CfgTipoDomicilio] (
    [CfgTipoDomicilioID]        INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoDomicilioClave]     VARCHAR (10) NOT NULL,
    [Nombre]                    VARCHAR (40) NOT NULL,
    [NombreCorto]               VARCHAR (15) NOT NULL,
    [Estatus]                   BIT          NOT NULL,
    [CfgSistemaTipoDomicilioID] INT          NOT NULL,
    CONSTRAINT [PK_CfgTipoDomicilio] PRIMARY KEY CLUSTERED ([CfgTipoDomicilioID] ASC),
    CONSTRAINT [FK_CfgTipoDomicilio_SistemaTipoDomicilio] FOREIGN KEY ([CfgSistemaTipoDomicilioID]) REFERENCES [dbo].[SistemaTipoDomicilio] ([SistemaTipoDomicilioID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoDomicilio_TipoDomicilioClave]
    ON [dbo].[CfgTipoDomicilio]([CfgTipoDomicilioClave] ASC);

