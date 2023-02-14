CREATE TABLE [dbo].[AdmisionArea] (
    [AreaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([AreaID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionArea] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

