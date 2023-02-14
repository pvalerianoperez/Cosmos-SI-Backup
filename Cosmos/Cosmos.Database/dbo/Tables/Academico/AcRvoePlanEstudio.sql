CREATE TABLE [dbo].[AcRvoePlanEstudio] (
    [RvoePlanEstudioID] INT NOT NULL IDENTITY,
    [RvoeID]        INT NULL,
    [PlanEstudioID] INT NULL,  
    CONSTRAINT [PK_AcRvoePlanEstudio] PRIMARY KEY ([RvoePlanEstudioID]), 
    CONSTRAINT [FK_AcRvoePlanEstudio_AcRvoe] FOREIGN KEY ([RvoeID]) REFERENCES [AcRvoe]([RvoeID]), 
    CONSTRAINT [FK_AcRvoePlanEstudio_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [AcPlanEstudio]([PlanEstudioID]), 
    CONSTRAINT [AK_AcRvoePlanEstudio_RvoeID_PlanEstudioID] UNIQUE ([RvoeID],[PlanEstudioID])
);

