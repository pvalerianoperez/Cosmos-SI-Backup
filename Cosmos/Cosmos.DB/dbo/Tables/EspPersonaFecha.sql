CREATE TABLE [dbo].[EspPersonaFecha] (
    [EspPersonaFechaID] INT           NOT NULL,
    [Fecha]             DATE          NOT NULL,
    [EspPersonaID]      INT           NOT NULL,
    [CfgTipoFechaID]    INT           NOT NULL,
    [Comentario]        VARCHAR (100) NOT NULL,
    [Predeterminado]    BIT           NOT NULL,
    CONSTRAINT [PK_EspFecha] PRIMARY KEY CLUSTERED ([EspPersonaFechaID] ASC),
    CONSTRAINT [FK_Fecha_CfgTipoFecha] FOREIGN KEY ([CfgTipoFechaID]) REFERENCES [dbo].[CfgTipoFecha] ([CfgTipoFechaID]),
    CONSTRAINT [FK_Fecha_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID])
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonaFecha_PersonaID_TipoFechaID_Fecha]
    ON [dbo].[EspPersonaFecha]([EspPersonaID] ASC, [CfgTipoFechaID] ASC, [Fecha] ASC);

