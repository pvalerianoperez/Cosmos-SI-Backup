CREATE TABLE [dbo].[AcSalidaTerminalProgramaEstudio] (
    [SalidaTerminalProgramaEstudioID] INT IDENTITY (1, 1) NOT NULL,
    [SalidaTerminalID]                INT NOT NULL,
    [ProgramaEstudioID]               INT NOT NULL,
    PRIMARY KEY CLUSTERED ([SalidaTerminalProgramaEstudioID] ASC),
    CONSTRAINT [FK_AcSalidaTerminalProgramaEstudio_AcProgramaEstudio] FOREIGN KEY ([ProgramaEstudioID]) REFERENCES [dbo].[AcProgramaEstudio] ([ProgramaEstudioID]),
    CONSTRAINT [FK_AcSalidaTerminalProgramaEstudio_AcSalidaTerminal] FOREIGN KEY ([SalidaTerminalID]) REFERENCES [dbo].[AcSalidaTerminal] ([SalidaTerminalID]),
    CONSTRAINT [AK_AcSalidaTerminalProgramaEstudio_SalidaTerminalID_ProgramaEstudioID] UNIQUE NONCLUSTERED ([SalidaTerminalID] ASC, [ProgramaEstudioID] ASC)
);

