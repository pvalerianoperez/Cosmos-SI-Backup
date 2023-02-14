CREATE TABLE [dbo].[AcProgramaAcademico] (
    [ProgramaAcademicoID]    INT           IDENTITY (1, 1) NOT NULL,
    [ProgramaAcademicoClave] VARCHAR (6)   NOT NULL,
    [Nombre]                 VARCHAR (80)  NOT NULL,
    [NombreCorto]            VARCHAR (15)  NOT NULL,
    [ExtraTexto1]            VARCHAR (500) NULL,
    [ExtraTexto2]            VARCHAR (500) NULL,
    [ExtraTexto3]            VARCHAR (500) NULL,
    [ExtraFecha1]            DATETIME      NULL,
    [ExtraFecha2]            DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ProgramaAcademicoID] ASC),
    CONSTRAINT [AK_AcProgramasAcademicos_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcProgramasAcademicos_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC),
    CONSTRAINT [AK_AcProgramasAcademicos_ProgramaAcademicoClave] UNIQUE NONCLUSTERED ([ProgramaAcademicoClave] ASC)
);

