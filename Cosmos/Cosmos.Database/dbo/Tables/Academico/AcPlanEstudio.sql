CREATE TABLE [dbo].[AcPlanEstudio] (
    [PlanEstudioID]                 INT          NOT NULL IDENTITY,
    [PlanEstudioClave]              VARCHAR (6)  NULL,
    [Nombre]                        VARCHAR (80) NOT NULL,
    [NombreCorto]                   VARCHAR (15) NULL,
    [Descripcion]                   VARCHAR (150) NULL,
    [SeccionID]                     INT          NOT NULL,
    [CalificacionMinimaAprobatoria] DECIMAL(5, 2)          NULL,
    [CreditosParaAcreditar]         INT          NULL,
    CONSTRAINT [PK_AcPlanEstudio] PRIMARY KEY CLUSTERED ([PlanEstudioID] ASC),
    CONSTRAINT [FK_AcPlanEstudio_AcSeccion] FOREIGN KEY ([SeccionID]) REFERENCES [dbo].[AcSeccion] ([SeccionID]), 
    CONSTRAINT [AK_AcPlanEstudio_PlanEstudioClave] UNIQUE ([PlanEstudioClave]), 
    CONSTRAINT [AK_AcPlanEstudio_Nombre] UNIQUE ([Nombre]), 
    CONSTRAINT [AK_AcPlanEstudio_NombreCorto] UNIQUE ([NombreCorto])
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcPlanEstudio_AcSeccion]
    ON [dbo].[AcPlanEstudio]([SeccionID] ASC);

