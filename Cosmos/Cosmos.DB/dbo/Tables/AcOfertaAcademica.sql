CREATE TABLE [dbo].[AcOfertaAcademica] (
    [OfertaAcademicaID] INT IDENTITY (1, 1) NOT NULL,
    [CicloID]           INT NOT NULL,
    [PlantelID]         INT NOT NULL,
    [SeccionID]         INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OfertaAcademicaID] ASC),
    CONSTRAINT [FK_AcOfertaAcademica_AcCiclo] FOREIGN KEY ([CicloID]) REFERENCES [dbo].[AcCiclo] ([CicloID]),
    CONSTRAINT [FK_AcOfertaAcademica_AcPlantel] FOREIGN KEY ([PlantelID]) REFERENCES [dbo].[AcPlantel] ([PlantelID]),
    CONSTRAINT [FK_AcOfertaAcademica_AcSeccion] FOREIGN KEY ([SeccionID]) REFERENCES [dbo].[AcSeccion] ([SeccionID]),
    CONSTRAINT [AK_AcOfertaAcademica_CicloID_PlantelID_SeccionID] UNIQUE NONCLUSTERED ([CicloID] ASC, [PlantelID] ASC, [SeccionID] ASC)
);

