CREATE TABLE [dbo].[AcOfertaAcademicaPlanEstudioTurno] (
    [OfertaAcademicaPlanEstudioTurnoID] INT IDENTITY (1, 1) NOT NULL,
    [OfertaAcademicaID]                 INT NOT NULL,
    [PlanEstudioID]                     INT NOT NULL,
    [TurnoID]                           INT NOT NULL,
    [RvoeID]                            INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OfertaAcademicaPlanEstudioTurnoID] ASC),
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcOfertaAcademica] FOREIGN KEY ([OfertaAcademicaID]) REFERENCES [dbo].[AcOfertaAcademica] ([OfertaAcademicaID]),
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [dbo].[AcPlanEstudio] ([PlanEstudioID]),
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcRvoeID] FOREIGN KEY ([RvoeID]) REFERENCES [dbo].[AcRvoe] ([RvoeID]),
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcTurnoID] FOREIGN KEY ([TurnoID]) REFERENCES [dbo].[AcTurno] ([TurnoID]),
    CONSTRAINT [AK_AcOfertaAcademicaPlanEstudioTurno_OfertaAcademicaID_PlanEstudioID_TurnoID] UNIQUE NONCLUSTERED ([OfertaAcademicaID] ASC, [PlanEstudioID] ASC, [TurnoID] ASC)
);

