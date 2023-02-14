CREATE TABLE [dbo].[AcProgramaEstudio] (
    [ProgramaEstudioID]     INT         IDENTITY (1, 1) NOT NULL,
    [PlanEstudioID]         INT         NOT NULL,
    [AsignaturaID]          INT         NOT NULL,
    [Clave]                 VARCHAR (6) NULL,
    [ProgramaEstudioTipoID] INT         NOT NULL,
    [AreaFormacionID]       INT         NOT NULL,
    [HorasTeoria]           INT         NULL,
    [HorasPractica]         INT         NULL,
    [HorasTotales]          INT         NULL,
    [Creditos]              INT         NULL,
    [DuracionSemanas]       INT         NULL,
    [Grado]                 INT         NULL,
    CONSTRAINT [PK_AcProgramaEstudio] PRIMARY KEY CLUSTERED ([ProgramaEstudioID] ASC),
    CONSTRAINT [FK_AcProgramaEstudio_AcAsignatura] FOREIGN KEY ([AsignaturaID]) REFERENCES [dbo].[AcAsignatura] ([AsignaturaID]),
    CONSTRAINT [FK_AcProgramaEstudio_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [dbo].[AcPlanEstudio] ([PlanEstudioID])
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcProgramaEstudio_AcAsignaturas]
    ON [dbo].[AcProgramaEstudio]([AsignaturaID] ASC);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcProgramaEstudio_AcPlanEstudio]
    ON [dbo].[AcProgramaEstudio]([PlanEstudioID] ASC);

