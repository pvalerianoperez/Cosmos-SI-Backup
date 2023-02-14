CREATE TABLE [dbo].[AcSalidaTerminalProgramaEstudio]
(
	[SalidaTerminalProgramaEstudioID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalidaTerminalID] INT NOT NULL, 
    [ProgramaEstudioID] INT NOT NULL, 
    CONSTRAINT [FK_AcSalidaTerminalProgramaEstudio_AcSalidaTerminal] FOREIGN KEY ([SalidaTerminalID]) REFERENCES [AcSalidaTerminal]([SalidaTerminalID]),
    CONSTRAINT [FK_AcSalidaTerminalProgramaEstudio_AcProgramaEstudio] FOREIGN KEY ([ProgramaEstudioID]) REFERENCES [AcProgramaEstudio]([ProgramaEstudioID]), 
    CONSTRAINT [AK_AcSalidaTerminalProgramaEstudio_SalidaTerminalID_ProgramaEstudioID] UNIQUE ([SalidaTerminalID],[ProgramaEstudioID])
)
