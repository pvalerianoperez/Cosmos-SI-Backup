CREATE TABLE [dbo].[DatoFacturacion] (
    [DatoFacturacionID] INT          IDENTITY (1, 1) NOT NULL,
    [EspPersonaID]      INT          NOT NULL,
    [RFC]               VARCHAR (20) NOT NULL,
    [DomicilioID]       INT          NOT NULL,
    CONSTRAINT [PK_DatoFacturacion] PRIMARY KEY CLUSTERED ([DatoFacturacionID] ASC),
    CONSTRAINT [FK_DatoFacturacion_Domicilio] FOREIGN KEY ([DomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID]),
    CONSTRAINT [FK_DatoFacturacion_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID])
);



