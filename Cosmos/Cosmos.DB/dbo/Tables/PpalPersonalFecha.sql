CREATE TABLE [dbo].[PpalPersonalFecha] (
    [PpalPersonalFechaID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalPersonalID]      INT           NOT NULL,
    [Fecha]               DATE          NOT NULL,
    [CfgTipoFechaID]      INT           NOT NULL,
    [Comentarios]         VARCHAR (100) NOT NULL,
    [Predeterminado]      BIT           NOT NULL,
    CONSTRAINT [PK_PersonalFecha] PRIMARY KEY CLUSTERED ([PpalPersonalFechaID] ASC),
    CONSTRAINT [FK_PersonalFecha_CfgTipoFecha] FOREIGN KEY ([CfgTipoFechaID]) REFERENCES [dbo].[CfgTipoFecha] ([CfgTipoFechaID]),
    CONSTRAINT [FK_PpalPersonalFecha_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID])
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonalFecha_PersonalID_TipoFechaID_Fecha]
    ON [dbo].[PpalPersonalFecha]([PpalPersonalID] ASC, [CfgTipoFechaID] ASC, [Fecha] ASC);

