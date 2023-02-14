CREATE TABLE [dbo].[AcProgramaEstudioTipo] (
    [ProgramaEstudioTipoID]    INT          IDENTITY (1, 1) NOT NULL,
    [ProgramaEstudioTipoClave] VARCHAR (6)  NULL,
    [Nombre]                   VARCHAR (80) NOT NULL,
    [NombreCorto]              VARCHAR (15) NULL,
    CONSTRAINT [PK_AcProgramaEstudioTipo] PRIMARY KEY CLUSTERED ([ProgramaEstudioTipoID] ASC),
    CONSTRAINT [AK_AcProgramaEstudioTipo_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

