CREATE TABLE [dbo].[AcRvoePlanEstudio] (
    [RvoePlanEstudioID] INT IDENTITY (1, 1) NOT NULL,
    [RvoeID]            INT NULL,
    [PlanEstudioID]     INT NULL,
    CONSTRAINT [PK_AcRvoePlanEstudio] PRIMARY KEY CLUSTERED ([RvoePlanEstudioID] ASC),
    CONSTRAINT [FK_AcRvoePlanEstudio_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [dbo].[AcPlanEstudio] ([PlanEstudioID]),
    CONSTRAINT [FK_AcRvoePlanEstudio_AcRvoe] FOREIGN KEY ([RvoeID]) REFERENCES [dbo].[AcRvoe] ([RvoeID]),
    CONSTRAINT [AK_AcRvoePlanEstudio_RvoeID_PlanEstudioID] UNIQUE NONCLUSTERED ([RvoeID] ASC, [PlanEstudioID] ASC)
);

