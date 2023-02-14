CREATE TABLE [dbo].[CalEventoTipo] (
    [EventoTipoID]    INT        IDENTITY (1, 1) NOT NULL,
    [EventoTipoClave] NCHAR (6)  NOT NULL,
    [Nombre]          NCHAR (80) NOT NULL,
    [NombreCorto]     NCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([EventoTipoID] ASC)
);

