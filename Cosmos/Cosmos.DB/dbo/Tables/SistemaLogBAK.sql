CREATE TABLE [dbo].[SistemaLogBAK] (
    [SistemaLogID]       INT           IDENTITY (1, 1) NOT NULL,
    [TablaNombre]        VARCHAR (100) NOT NULL,
    [TablaID]            INT           NOT NULL,
    [TablaColumna1]      VARCHAR (100) NOT NULL,
    [TablaColumna2]      VARCHAR (100) NOT NULL,
    [Operacion]          VARCHAR (10)  NOT NULL,
    [UsuarioID]          INT           NOT NULL,
    [Descripcion]        VARCHAR (500) NOT NULL,
    [Cambios]            TEXT          NOT NULL,
    [IpAddress]          VARCHAR (40)  NOT NULL,
    [HostName]           VARCHAR (50)  NOT NULL,
    [FechaHoraCambioUTC] DATETIME2 (7) CONSTRAINT [DF__tmp_ms_xx__Fecha__417994D0] DEFAULT (sysutcdatetime()) NOT NULL,
    CONSTRAINT [PK__tmp_ms_x__90845A4CD90BA975] PRIMARY KEY CLUSTERED ([SistemaLogID] ASC),
    CONSTRAINT [FK_SistemaLogBAK_SegUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID])
);

