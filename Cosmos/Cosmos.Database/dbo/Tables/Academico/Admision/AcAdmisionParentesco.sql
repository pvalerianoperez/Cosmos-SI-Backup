CREATE TABLE [dbo].[AcAdmisionParentesco] (
    [ParentescoID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ParentescoID] ASC),
    CONSTRAINT [Ak_Admision_AdmisionParentesco] UNIQUE NONCLUSTERED ([Nombre] ASC)
);


