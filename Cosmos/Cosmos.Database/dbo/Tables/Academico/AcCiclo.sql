CREATE TABLE [dbo].[AcCiclo] (
    [CicloID]         INT           NOT NULL IDENTITY,
    [CicloClave]      VARCHAR (6)   NULL,
    [Nombre]          VARCHAR (80)  NOT NULL,
    [NombreCorto]     VARCHAR (15)  NULL,
    [Descripcion]     VARCHAR (150) NULL,
    [CalendarioID]    INT           NOT NULL,
    [FechaInicio]     DATETIME      NOT NULL,
    [FechaFinal]      DATETIME      NOT NULL,
    [CicloIDAnterior] INT           NULL,
    [CicloTipoID]     INT           NOT NULL,
    CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED ([CicloID] ASC),
    CONSTRAINT [FK_AcCiclo_AcCalendario] FOREIGN KEY ([CalendarioID]) REFERENCES [dbo].[AcCalendario] ([CalendarioID]),
    CONSTRAINT [FK_AcCiclo_AcCiclo] FOREIGN KEY ([CicloIDAnterior]) REFERENCES [dbo].[AcCiclo] ([CicloID]),
    CONSTRAINT [FK_AcCiclo_AcCicloTipo] FOREIGN KEY ([CicloTipoID]) REFERENCES [dbo].[AcCicloTipo] ([CicloTipoID])
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcCiclo_AcCicloTipo]
    ON [dbo].[AcCiclo]([CicloTipoID] ASC);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcCiclo_AcCalendario]
    ON [dbo].[AcCiclo]([CalendarioID] ASC);

