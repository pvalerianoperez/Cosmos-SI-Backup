CREATE TABLE [dbo].[CalCalendarioTipo] (
    [CalendarioTipoID]    INT        IDENTITY (1, 1) NOT NULL,
    [CalendarioTipoClave] NCHAR (6)  NULL,
    [Nombre]              NCHAR (80) NULL,
    [NombreCorto]         NCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([CalendarioTipoID] ASC)
);

