CREATE TABLE [dbo].[AcPeriodoEvaluacion] (
    [PeriodoEvaluacionID]         INT          NOT NULL IDENTITY,
    [PeriodoEvaluacionClave]      VARCHAR (6)  NULL,
    [Nombre]                      VARCHAR (80) NOT NULL,
    [NombreCorto]                 VARCHAR (15) NULL,
    [Descripcion]				  VARCHAR (150) NULL,
    [PeriodoEvaluacionIDAnterior] INT          NULL,
    [FechaInicio]                 DATETIME     NOT NULL,
    [FechaFinal]                  DATETIME     NOT NULL,
    [CicloID]                     INT          NOT NULL,
    CONSTRAINT [PK_AcPeriodo] PRIMARY KEY CLUSTERED ([PeriodoEvaluacionID] ASC), 
    CONSTRAINT [AK_AcPeriodoEvaluacion_PeriodoEvaluacionClave] UNIQUE ([PeriodoEvaluacionClave]), 
    CONSTRAINT [AK_AcPeriodoEvaluacion_Nombre] UNIQUE ([Nombre]), 
    CONSTRAINT [AK_AcPeriodoEvaluacion_NombreCorto] UNIQUE ([NombreCorto])
);

