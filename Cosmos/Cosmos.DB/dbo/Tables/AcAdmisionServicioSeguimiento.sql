CREATE TABLE [dbo].[AcAdmisionServicioSeguimiento] (
    [ServicioSeguimientoID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]                VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ServicioSeguimientoID] ASC),
    CONSTRAINT [AK_AcAdmision_AdmisionServicioSeguimiento] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

