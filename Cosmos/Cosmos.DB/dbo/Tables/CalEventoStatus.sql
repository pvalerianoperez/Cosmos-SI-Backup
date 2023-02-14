CREATE TABLE [dbo].[CalEventoStatus] (
    [EventoStatusID]    INT        IDENTITY (1, 1) NOT NULL,
    [EventoStatusClave] NCHAR (6)  NOT NULL,
    [Nombre]            NCHAR (80) NOT NULL,
    [NombreCorto]       NCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([EventoStatusID] ASC)
);

