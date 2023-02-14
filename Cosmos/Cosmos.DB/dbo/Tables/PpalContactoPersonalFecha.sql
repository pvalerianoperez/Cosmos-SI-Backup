CREATE TABLE [dbo].[PpalContactoPersonalFecha] (
    [PpalContactoPersonalFechaID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalContactoPersonalID]      INT           NOT NULL,
    [Fecha]                       DATE          NOT NULL,
    [CfgTipoFechaID]              INT           NOT NULL,
    [Comentarios]                 VARCHAR (100) NOT NULL,
    [Predeterminado]              BIT           NOT NULL,
    CONSTRAINT [PK_PpalContactoPersonalFechaID] PRIMARY KEY CLUSTERED ([PpalContactoPersonalFechaID] ASC),
    CONSTRAINT [FK_PpalContactoPersonal_ContactoPersonalFecha] FOREIGN KEY ([PpalContactoPersonalID]) REFERENCES [dbo].[PpalContactoPersonal] ([PpalContactoPersonalID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PpalContactoPersonalFecha_CfgTipoFecha] FOREIGN KEY ([CfgTipoFechaID]) REFERENCES [dbo].[CfgTipoFecha] ([CfgTipoFechaID])
);


GO
CREATE NONCLUSTERED INDEX [IX_PpalContactoPersonalFecha_PpalContactoPersonalID_TipoFechaID_Fecha]
    ON [dbo].[PpalContactoPersonalFecha]([PpalContactoPersonalID] ASC, [CfgTipoFechaID] ASC, [Fecha] ASC);

