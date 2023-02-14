CREATE TABLE [dbo].[AcAdmisionProfesion] (
    [ProfesionID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ProfesionID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionProfesion] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

