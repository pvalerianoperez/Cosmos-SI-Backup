CREATE TABLE [dbo].[CalEventoTipo]
(
	[EventoTipoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventoTipoClave] NCHAR(6) NOT NULL, 
    [Nombre] NCHAR(80) NOT NULL, 
    [NombreCorto] NCHAR(15) NOT NULL
)
