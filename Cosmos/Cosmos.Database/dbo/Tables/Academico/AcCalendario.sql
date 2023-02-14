CREATE TABLE [dbo].[AcCalendario] (
    [CalendarioID]         INT           NOT NULL IDENTITY,
    [CalendarioClave]      VARCHAR (6)   NULL,
    [Nombre]               VARCHAR (80)  NOT NULL,
    [NombreCorto]          VARCHAR (15)  NULL,
    [Descripcion]          VARCHAR (100) NULL,
    [FechaInicio]          DATETIME      NOT NULL,
    [FechaFinal]           DATETIME      NOT NULL,
    [CalendarioIDAnterior] INT            NULL,
    CONSTRAINT [PK_AcCalendario] PRIMARY KEY CLUSTERED ([CalendarioID] ASC),
    CONSTRAINT [IX_AcCalendario_Clave] UNIQUE NONCLUSTERED ([CalendarioClave] ASC),
    CONSTRAINT [IX_AcCalendario_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [IX_AcCalendario_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);

