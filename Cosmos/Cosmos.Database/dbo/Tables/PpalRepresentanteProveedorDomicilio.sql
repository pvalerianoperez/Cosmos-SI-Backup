CREATE TABLE [dbo].[PpalRepresentanteProveedorDomicilio] (
    [PpalRepresentanteProveedorDomicilioID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalRepresentanteProveedorID]          INT           NOT NULL,
    [EspDomicilioID]                        INT           NOT NULL,
    [Comentario]                            VARCHAR (100) NOT NULL,
    [Predeterminado]                        BIT           NOT NULL,
    [CfgTipoDomicilioID]                    INT           NOT NULL,
    CONSTRAINT [PK_PpalRepresentanteProveedorDomicilioID] PRIMARY KEY CLUSTERED ([PpalRepresentanteProveedorDomicilioID] ASC),
    CONSTRAINT [FK_PpalRepresentanteProveedorDomicilio_CfgTipoDomicilio] FOREIGN KEY ([CfgTipoDomicilioID]) REFERENCES [dbo].[CfgTipoDomicilio] ([CfgTipoDomicilioID]),
    CONSTRAINT [FK_PpalRepresentanteProveedorDomicilio_Domicilio] FOREIGN KEY ([EspDomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID]),
    CONSTRAINT [FK_PpalRepresentanteProveedorDomicilio_PpalRepresentanteProveedor] FOREIGN KEY ([PpalRepresentanteProveedorID]) REFERENCES [dbo].[PpalRepresentanteProveedor] ([PpalRepresentanteProveedorID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalRepresentanteProveedorDomicilio_PpalRepresentanteProveedorID_DomicilioID_TipoDomicilioID]
    ON [dbo].[PpalRepresentanteProveedorDomicilio]([PpalRepresentanteProveedorID] ASC, [EspDomicilioID] ASC, [CfgTipoDomicilioID] ASC);

