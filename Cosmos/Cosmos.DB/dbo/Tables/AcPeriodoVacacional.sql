CREATE TABLE [dbo].[AcPeriodoVacacional] (
    [PeriodoVacacionalID]    INT           IDENTITY (1, 1) NOT NULL,
    [PeriodoVacacionalClave] VARCHAR (6)   NULL,
    [Nombre]                 VARCHAR (80)  NOT NULL,
    [NombreCorto]            VARCHAR (15)  NULL,
    [Descripcion]            VARCHAR (150) NULL,
    [CicloID]                INT           NOT NULL,
    [FechaInicio]            DATETIME      NOT NULL,
    [FechaFinal]             DATETIME      NOT NULL,
    CONSTRAINT [PK_AcPeriodoVacacional] PRIMARY KEY CLUSTERED ([PeriodoVacacionalID] ASC),
    CONSTRAINT [FK_AcPeriodoVacacional_AcCiclo] FOREIGN KEY ([CicloID]) REFERENCES [dbo].[AcCiclo] ([CicloID]),
    CONSTRAINT [AK_AcPeriodoVacacional_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcPeriodoVacacional_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC),
    CONSTRAINT [AK_AcPeriodoVacacional_PeriodoVacacionalClave] UNIQUE NONCLUSTERED ([PeriodoVacacionalClave] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcPeriodoVacacional_AcCiclo]
    ON [dbo].[AcPeriodoVacacional]([CicloID] ASC);

