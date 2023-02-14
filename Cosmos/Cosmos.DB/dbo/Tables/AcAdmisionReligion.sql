CREATE TABLE [dbo].[AcAdmisionReligion] (
    [ReligionID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]     VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ReligionID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionReligion] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

