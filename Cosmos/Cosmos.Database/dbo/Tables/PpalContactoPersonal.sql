CREATE TABLE [dbo].[PpalContactoPersonal] (
    [PpalContactoPersonalID] INT IDENTITY (1, 1) NOT NULL,
    [PpalPersonalID]         INT NOT NULL,
    [EspPersonaID]           INT NOT NULL,
    [TipoContactoPersonalID] INT NOT NULL,
    CONSTRAINT [PK_PpalContactoPersonalID] PRIMARY KEY CLUSTERED ([PpalContactoPersonalID] ASC),
    CONSTRAINT [FK_PpalContactoPersonal_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID]),
    CONSTRAINT [FK_PpalContactoPersonal_SistemaPersonalTipoContacto] FOREIGN KEY ([TipoContactoPersonalID]) REFERENCES [dbo].[SistemaTipoContactoPersonal] ([TipoContactoPersonalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalContactoPersonal_PpalPersonalID_PersonalD]
    ON [dbo].[PpalContactoPersonal]([PpalPersonalID] ASC, [EspPersonaID] ASC);

