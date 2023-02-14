CREATE TABLE [dbo].[AcPlanEstudio] (
    [PlanEstudioID]                 INT            IDENTITY (1, 1) NOT NULL,
    [PlanEstudioClave]              VARCHAR (6)    NULL,
    [Nombre]                        VARCHAR (80)   NOT NULL,
    [NombreCorto]                   VARCHAR (15)   NULL,
    [Descripcion]                   VARCHAR (150)  NULL,
    [SeccionID]                     INT            NOT NULL,
    [CalificacionMinimaAprobatoria] DECIMAL (5, 2) NULL,
    [CreditosParaAcreditar]         INT            NULL,
    CONSTRAINT [PK_AcPlanEstudio] PRIMARY KEY CLUSTERED ([PlanEstudioID] ASC),
    CONSTRAINT [FK_AcPlanEstudio_AcSeccion] FOREIGN KEY ([SeccionID]) REFERENCES [dbo].[AcSeccion] ([SeccionID]),
    CONSTRAINT [AK_AcPlanEstudio_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcPlanEstudio_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC),
    CONSTRAINT [AK_AcPlanEstudio_PlanEstudioClave] UNIQUE NONCLUSTERED ([PlanEstudioClave] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcPlanEstudio_AcSeccion]
    ON [dbo].[AcPlanEstudio]([SeccionID] ASC);

