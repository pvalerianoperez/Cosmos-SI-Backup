CREATE TABLE [dbo].[AcAdmisionMedioContacto] (
    [MedioContactoID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MedioContactoID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionMedioContacto] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

