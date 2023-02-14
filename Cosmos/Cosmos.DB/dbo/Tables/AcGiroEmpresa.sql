CREATE TABLE [dbo].[AcGiroEmpresa] (
    [GiroEmpresaID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([GiroEmpresaID] ASC),
    CONSTRAINT [Ak_Admision_AdmisionGiroEmpresa] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

