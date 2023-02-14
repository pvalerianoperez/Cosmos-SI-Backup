CREATE TABLE [dbo].[AcAreaFormacion] (
    [AreaFormacionID]    INT          IDENTITY (1, 1) NOT NULL,
    [AreaFormacionClave] VARCHAR (6)  NULL,
    [Nombre]             VARCHAR (80) NOT NULL,
    [NombreCorto]        VARCHAR (15) NULL,
    CONSTRAINT [PK_AcAreaFormacion] PRIMARY KEY CLUSTERED ([AreaFormacionID] ASC),
    CONSTRAINT [AK_AcAreaFormacion_AreaFormacionClave] UNIQUE NONCLUSTERED ([AreaFormacionClave] ASC),
    CONSTRAINT [AK_AcAreaFormacion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcAreaFormacion_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);

