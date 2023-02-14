CREATE TABLE [dbo].[SistemaLog] (
    [SistemaLogID]       INT           IDENTITY (1, 1) NOT NULL,
    [TablaNombre]        VARCHAR (100) NOT NULL,
    [TablaID]            INT           NULL,
    [TablaColumna1]      VARCHAR (100) NULL,
    [TablaColumna2]      VARCHAR (100) NULL,
    [Operacion]          VARCHAR (10)  NOT NULL,
    [UserID]             INT           NOT NULL,
    [Descripcion]        VARCHAR (500) NULL,
    [Cambios]            TEXT          NOT NULL,
    [IpAddress]          VARCHAR (40)  NULL,
    [HostName]           VARCHAR (50)  NULL,
    [FechaHoraCambioUTC] DATETIME2 (7) DEFAULT (sysutcdatetime()) NULL,
    PRIMARY KEY CLUSTERED ([SistemaLogID] ASC)
);

