CREATE TABLE [dbo].[AcProgramaEstudioTipo] (
    [ProgramaEstudioTipoID]    INT          NOT NULL IDENTITY,
    [ProgramaEstudioTipoClave] VARCHAR (6) NULL,
    [Nombre]                   VARCHAR (80) NOT NULL,
    [NombreCorto]              VARCHAR (15) NULL,
    CONSTRAINT [PK_AcProgramaEstudioTipo] PRIMARY KEY CLUSTERED ([ProgramaEstudioTipoID] ASC), 
    CONSTRAINT [AK_AcProgramaEstudioTipo_Nombre] UNIQUE ([Nombre])
);

