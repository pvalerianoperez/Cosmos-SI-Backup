CREATE TABLE [dbo].[AcAdmisionZona] (
    [ZonaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ZonaID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionZona] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

