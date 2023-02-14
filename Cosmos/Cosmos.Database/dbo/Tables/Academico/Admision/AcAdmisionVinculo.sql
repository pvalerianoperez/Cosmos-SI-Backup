CREATE TABLE [dbo].[AcAdmisionVinculo] (
    [VinculoID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([VinculoID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionVinculo] UNIQUE NONCLUSTERED ([Nombre] ASC)
);


