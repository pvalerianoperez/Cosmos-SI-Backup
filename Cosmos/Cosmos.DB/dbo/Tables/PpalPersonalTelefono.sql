CREATE TABLE [dbo].[PpalPersonalTelefono] (
    [PpalPersonalTelefonoID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalPersonalID]         INT           NOT NULL,
    [EspTelefonoID]          INT           NOT NULL,
    [Extension]              VARCHAR (10)  NOT NULL,
    [Predeterminado]         BIT           NOT NULL,
    [Comentarios]            VARCHAR (100) NOT NULL,
    [CfgUsoTelefonoID]       INT           NOT NULL,
    CONSTRAINT [PK_PpalPersonalTelefono] PRIMARY KEY CLUSTERED ([PpalPersonalTelefonoID] ASC),
    CONSTRAINT [FK_PpalPersonalTelefono_CfgUsoTelefonoID] FOREIGN KEY ([CfgUsoTelefonoID]) REFERENCES [dbo].[CfgUsoTelefono] ([CfgUsoTelefonoID]),
    CONSTRAINT [FK_PpalPersonalTelefono_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID]),
    CONSTRAINT [FK_PpalPersonalTelefono_Telefono] FOREIGN KEY ([EspTelefonoID]) REFERENCES [dbo].[EspTelefono] ([EspTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalPersonalTelefono_PersonalID_TelefonoID_Extension]
    ON [dbo].[PpalPersonalTelefono]([PpalPersonalID] ASC, [EspTelefonoID] ASC, [Extension] ASC);

