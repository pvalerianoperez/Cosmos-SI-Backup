CREATE TABLE [dbo].[AcOfertaAcademicaPlanEstudioTurno]
(
	[OfertaAcademicaPlanEstudioTurnoID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OfertaAcademicaID] INT NOT NULL, 
    [PlanEstudioID] INT NOT NULL, 
    [TurnoID] INT NOT NULL, 
    [RvoeID] INT NOT NULL, 
    CONSTRAINT [AK_AcOfertaAcademicaPlanEstudioTurno_OfertaAcademicaID_PlanEstudioID_TurnoID] UNIQUE ([OfertaAcademicaID],[PlanEstudioID],[TurnoID]), 
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcOfertaAcademica] FOREIGN KEY ([OfertaAcademicaID]) REFERENCES [AcOfertaAcademica]([OfertaAcademicaID]), 
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [AcPlanEstudio]([PlanEstudioID]), 
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcTurnoID] FOREIGN KEY ([TurnoID]) REFERENCES [AcTurno]([TurnoID]), 
    CONSTRAINT [FK_AcOfertaAcademicaPlanEstudioTurno_AcRvoeID] FOREIGN KEY ([RvoeID]) REFERENCES [AcRvoe]([RvoeID])
)
