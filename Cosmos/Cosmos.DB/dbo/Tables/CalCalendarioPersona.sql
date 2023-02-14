CREATE TABLE [dbo].[CalCalendarioPersona] (
    [CalendarioPersonaID]  INT IDENTITY (1, 1) NOT NULL,
    [CalendarioID]         INT NOT NULL,
    [EspPersonaID]         INT NOT NULL,
    [CalendarioPermisoInt] INT DEFAULT ((3)) NOT NULL,
    [Dueno]                BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([CalendarioPersonaID] ASC),
    CONSTRAINT [FK_CalCalendarioPersona_CalCalendario] FOREIGN KEY ([CalendarioID]) REFERENCES [dbo].[CalCalendario] ([CalendarioID]),
    CONSTRAINT [FK_CalCalendarioPersona_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID]),
    CONSTRAINT [AK_CalCalendarioPersona_Calendario_Persona] UNIQUE NONCLUSTERED ([CalendarioID] ASC, [EspPersonaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CalCalendarioPersona_Dueno]
    ON [dbo].[CalCalendarioPersona]([CalendarioID] ASC, [Dueno] ASC) WHERE ([Dueno]=(1));

