CREATE TABLE [dbo].[AcSalidaTerminal] (
    [SalidaTerminalID]    INT           IDENTITY (1, 1) NOT NULL,
    [SalidaTerminalClave] VARCHAR (6)   NULL,
    [Nombre]              VARCHAR (80)  NOT NULL,
    [NombreCorto]         VARCHAR (15)  NULL,
    [Descripcion]         VARCHAR (150) NULL,
    [PlanEstudioID]       INT           NOT NULL,
    [Activa]              BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([SalidaTerminalID] ASC),
    CONSTRAINT [FK_AcSalidaTerminal_AcPlanEstudio] FOREIGN KEY ([PlanEstudioID]) REFERENCES [dbo].[AcPlanEstudio] ([PlanEstudioID]),
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_Nombre] UNIQUE NONCLUSTERED ([PlanEstudioID] ASC, [Nombre] ASC),
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_NombreCorto] UNIQUE NONCLUSTERED ([PlanEstudioID] ASC, [NombreCorto] ASC),
    CONSTRAINT [AK_AcSalidaTerminal_PlanEstudioID_SalidaTerminalClave] UNIQUE NONCLUSTERED ([PlanEstudioID] ASC, [SalidaTerminalClave] ASC)
);

