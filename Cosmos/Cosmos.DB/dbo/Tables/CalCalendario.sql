CREATE TABLE [dbo].[CalCalendario] (
    [CalendarioID]     INT          IDENTITY (1, 1) NOT NULL,
    [CalendarioClave]  VARCHAR (6)  NULL,
    [Nombre]           VARCHAR (80) NULL,
    [NombreCorto]      VARCHAR (15) NULL,
    [CalendarioTipoID] INT          NOT NULL,
    [Borrado]          BIT          DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([CalendarioID] ASC)
);

