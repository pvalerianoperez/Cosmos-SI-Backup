CREATE TABLE [dbo].[PpalContactoPersonalTelefono] (
    [PpalContactoPersonalTelefonoID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalContactoPersonalID]         INT           NOT NULL,
    [EspTelefonoID]                  INT           NOT NULL,
    [Extension]                      VARCHAR (10)  NOT NULL,
    [Predeterminado]                 BIT           NOT NULL,
    [Comentarios]                    VARCHAR (100) NOT NULL,
    [CfgUsoTelefonoID]               INT           NOT NULL,
    CONSTRAINT [PK_PpalContactoPersonalTelefono] PRIMARY KEY CLUSTERED ([PpalContactoPersonalTelefonoID] ASC),
    CONSTRAINT [FK_PpalContactoPersonalTelefono_CfgUsoTelefonoID] FOREIGN KEY ([CfgUsoTelefonoID]) REFERENCES [dbo].[CfgUsoTelefono] ([CfgUsoTelefonoID]),
    CONSTRAINT [FK_PpalContactoPersonalTelefono_PpalContactoPersonal] FOREIGN KEY ([PpalContactoPersonalID]) REFERENCES [dbo].[PpalContactoPersonal] ([PpalContactoPersonalID]) ON DELETE CASCADE,
    CONSTRAINT [FK_PpalContactoPersonalTelefono_Telefono] FOREIGN KEY ([EspTelefonoID]) REFERENCES [dbo].[EspTelefono] ([EspTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalContactoPersonalTelefono_PpalContactoPersonalID_TelefonoID_Extension]
    ON [dbo].[PpalContactoPersonalTelefono]([PpalContactoPersonalID] ASC, [EspTelefonoID] ASC, [Extension] ASC);

