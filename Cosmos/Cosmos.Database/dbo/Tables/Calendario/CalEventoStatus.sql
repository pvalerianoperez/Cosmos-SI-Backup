CREATE TABLE [dbo].[CalEventoStatus]
(
	[EventoStatusID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventoStatusClave] NCHAR(6) NOT NULL, 
    [Nombre] NCHAR(80) NOT NULL, 
    [NombreCorto] NCHAR(15) NOT NULL
)
