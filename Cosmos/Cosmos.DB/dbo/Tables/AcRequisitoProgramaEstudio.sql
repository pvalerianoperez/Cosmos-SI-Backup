CREATE TABLE [dbo].[AcRequisitoProgramaEstudio] (
    [RequisitoProgramaEstudioID]      INT IDENTITY (1, 1) NOT NULL,
    [SalidaTerminalProgramaEstudioID] INT NULL,
    [ProgramaEstudioID]               INT NOT NULL,
    [ProgramaEstudioIDPrerrequisito]  INT NULL,
    [ProgramaEstudioIDCondicionalOR]  INT NULL,
    [ProgramaEstudioIDSimultanea]     INT NULL,
    [Creditos]                        INT NULL,
    PRIMARY KEY CLUSTERED ([RequisitoProgramaEstudioID] ASC),
    CONSTRAINT [FK_AcRequisitoProgramaEstudio_AcProgramaEstudio] FOREIGN KEY ([ProgramaEstudioID]) REFERENCES [dbo].[AcProgramaEstudio] ([ProgramaEstudioID]),
    CONSTRAINT [FK_AcRequisitoProgramaEstudio_AcSalidaTermnial] FOREIGN KEY ([SalidaTerminalProgramaEstudioID]) REFERENCES [dbo].[AcSalidaTerminalProgramaEstudio] ([SalidaTerminalProgramaEstudioID])
);

