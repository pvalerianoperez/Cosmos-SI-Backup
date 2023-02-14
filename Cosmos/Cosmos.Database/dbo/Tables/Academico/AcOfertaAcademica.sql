CREATE TABLE [dbo].[AcOfertaAcademica]
(
	[OfertaAcademicaID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CicloID] INT NOT NULL, 
    [PlantelID] INT NOT NULL, 
    [SeccionID] INT NOT NULL, 
    CONSTRAINT [AK_AcOfertaAcademica_CicloID_PlantelID_SeccionID] UNIQUE ([CicloID],[PlantelID],[SeccionID]), 
    CONSTRAINT [FK_AcOfertaAcademica_AcCiclo] FOREIGN KEY ([CicloID]) REFERENCES [AcCiclo]([CicloID]), 
    CONSTRAINT [FK_AcOfertaAcademica_AcPlantel] FOREIGN KEY ([PlantelID]) REFERENCES [AcPlantel]([PlantelID]), 
    CONSTRAINT [FK_AcOfertaAcademica_AcSeccion] FOREIGN KEY ([SeccionID]) REFERENCES [AcSeccion]([SeccionID])
)
