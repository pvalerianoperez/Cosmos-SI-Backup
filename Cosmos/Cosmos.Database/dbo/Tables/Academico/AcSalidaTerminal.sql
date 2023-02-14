CREATE TABLE [dbo].[AcSalidaTerminal]
(
	[SalidaTerminalID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalidaTerminalClave] VARCHAR(6) NULL, 
    [Nombre] VARCHAR(80) NOT NULL, 
    [NombreCorto] VARCHAR(15) NULL, 
    [Descripcion] VARCHAR(150) NULL, 
    [PlanEstudioID] INT NOT NULL, 
    [Activa] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_SalidaTerminalClave] UNIQUE ([PlanEstudioID],[SalidaTerminalClave]),
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_Nombre] UNIQUE ([PlanEstudioID],[Nombre]),
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_NombreCorto] UNIQUE ([PlanEstudioID],[NombreCorto]), 
    CONSTRAINT [FK_AcSalidaTerminal_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [AcPlanEstudio]([PlanEstudioID])
)
