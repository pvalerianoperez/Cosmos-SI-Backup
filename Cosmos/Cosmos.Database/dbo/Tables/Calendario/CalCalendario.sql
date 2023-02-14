CREATE TABLE [dbo].[CalCalendario]
(
	[CalendarioID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CalendarioClave] VARCHAR(6) NULL, 
    [Nombre] VARCHAR(80) NULL, 
    [NombreCorto] VARCHAR(15) NULL, 
    [CalendarioTipoID] INT NOT NULL, 
    [Borrado] BIT NOT NULL DEFAULT 0
)
