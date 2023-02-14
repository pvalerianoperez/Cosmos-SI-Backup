CREATE TABLE [dbo].[AcPlantel] (
    [PlantelID]    INT          NOT NULL IDENTITY,
    [PlantelClave] VARCHAR (6)  NULL,
    [Nombre]       VARCHAR (80) NOT NULL,
    [NombreCorto]  VARCHAR (15) NULL,
    [SucursalID] INT NOT NULL, 
    CONSTRAINT [PK_AcPlantel] PRIMARY KEY CLUSTERED ([PlantelID] ASC)
);

