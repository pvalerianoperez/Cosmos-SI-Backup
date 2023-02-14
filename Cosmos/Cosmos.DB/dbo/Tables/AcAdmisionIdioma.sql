CREATE TABLE [dbo].[AcAdmisionIdioma] (
    [IdiomaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([IdiomaID] ASC),
    CONSTRAINT [Ac_Admision_AdmisionIdioma] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

