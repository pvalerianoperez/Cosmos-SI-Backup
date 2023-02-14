CREATE TABLE [dbo].[CalCalendarioTipo]
(
	[CalendarioTipoID] INT NOT NULL PRIMARY KEY IDENTITY,
    [CalendarioTipoClave] NCHAR(6) NULL, 
    [Nombre] NCHAR(80) NULL, 
    [NombreCorto] NCHAR(15) NULL, 
)
