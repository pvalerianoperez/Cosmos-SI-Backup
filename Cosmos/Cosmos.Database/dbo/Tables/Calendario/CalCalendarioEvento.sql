CREATE TABLE [dbo].[CalCalendarioEvento]
(
	[CalendarioEventoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CalendarioID] INT NOT NULL, 
    [EventoID] INT NOT NULL, 
    [EventoPadreID] INT NULL, 
    CONSTRAINT [AK_CalCalendarioEvento_CalendarioID_EventoID] UNIQUE ([CalendarioID],[EventoID]), 
    CONSTRAINT [FK_CalCalendarioEvento_CalCalendario] FOREIGN KEY ([CalendarioID]) REFERENCES [CalCalendario]([CalendarioID]),
    CONSTRAINT [FK_CalCalendarioEvento_CalEvento] FOREIGN KEY ([EventoID]) REFERENCES [CalEvento]([EventoID])
)
