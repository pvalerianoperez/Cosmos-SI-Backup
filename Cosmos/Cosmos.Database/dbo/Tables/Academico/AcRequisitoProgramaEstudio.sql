CREATE TABLE [dbo].[AcRequisitoProgramaEstudio]
(
	[RequisitoProgramaEstudioID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalidaTerminalProgramaEstudioID] INT NULL, 
    [ProgramaEstudioID] INT NOT NULL, 
    [ProgramaEstudioIDPrerrequisito] INT NULL, 
    [ProgramaEstudioIDCondicionalOR] INT NULL, 
    [ProgramaEstudioIDSimultanea] INT NULL, 
    [Creditos] INT NULL, 
    CONSTRAINT [FK_AcRequisitoProgramaEstudio_AcProgramaEstudio] FOREIGN KEY ([ProgramaEstudioID]) REFERENCES [AcProgramaEstudio]([ProgramaEstudioID]), 
    CONSTRAINT [FK_AcRequisitoProgramaEstudio_AcSalidaTermnial] FOREIGN KEY ([SalidaTerminalProgramaEstudioID]) REFERENCES [AcSalidaTerminalProgramaEstudio]([SalidaTerminalProgramaEstudioID])
)
