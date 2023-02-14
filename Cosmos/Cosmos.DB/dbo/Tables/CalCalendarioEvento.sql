CREATE TABLE [dbo].[CalCalendarioEvento] (
    [CalendarioEventoID] INT IDENTITY (1, 1) NOT NULL,
    [CalendarioID]       INT NOT NULL,
    [EventoID]           INT NOT NULL,
    [EventoPadreID]      INT NULL,
    PRIMARY KEY CLUSTERED ([CalendarioEventoID] ASC),
    CONSTRAINT [FK_CalCalendarioEvento_CalCalendario] FOREIGN KEY ([CalendarioID]) REFERENCES [dbo].[CalCalendario] ([CalendarioID]),
    CONSTRAINT [FK_CalCalendarioEvento_CalEvento] FOREIGN KEY ([EventoID]) REFERENCES [dbo].[CalEvento] ([EventoID]),
    CONSTRAINT [AK_CalCalendarioEvento_CalendarioID_EventoID] UNIQUE NONCLUSTERED ([CalendarioID] ASC, [EventoID] ASC)
);

