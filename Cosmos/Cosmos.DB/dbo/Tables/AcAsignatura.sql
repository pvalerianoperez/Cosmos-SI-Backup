CREATE TABLE [dbo].[AcAsignatura] (
    [AsignaturaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (80) NOT NULL,
    PRIMARY KEY CLUSTERED ([AsignaturaID] ASC),
    CONSTRAINT [AK_AcAsignatura_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

