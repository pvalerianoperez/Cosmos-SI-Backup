CREATE TABLE [dbo].[CfgPeriodoOperativo] (
    [CfgPeriodoOperativoID]   INT          IDENTITY (1, 1) NOT NULL,
    [CfgEjercicioOperativoID] INT          NOT NULL,
    [CfgPeriodoClave]         VARCHAR (6)  NOT NULL,
    [Nombre]                  VARCHAR (20) NOT NULL,
    [NombreCorto]             VARCHAR (6)  NOT NULL,
    [PeriodoOrden]            INT          NOT NULL,
    [FechaInicial]            DATE         NOT NULL,
    [FechaFinal]              DATE         NOT NULL,
    [FechaEjercePresupuesto]  DATE         NOT NULL,
    CONSTRAINT [PK_CfgPeriodoOperativo] PRIMARY KEY CLUSTERED ([CfgPeriodoOperativoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PeriodoOperativo_EjercicioOperativoID_PeriodoClave]
    ON [dbo].[CfgPeriodoOperativo]([CfgEjercicioOperativoID] ASC, [CfgPeriodoClave] ASC);

