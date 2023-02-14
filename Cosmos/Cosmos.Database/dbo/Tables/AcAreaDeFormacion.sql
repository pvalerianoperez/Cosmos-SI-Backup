CREATE TABLE [dbo].[AcAreaDeFormacion] (
    [AreaDeFormacionID]    INT          IDENTITY (1, 1) NOT NULL,
    [AreaDeFormacionClave] VARCHAR (6)  NOT NULL,
    [Nombre]               VARCHAR (80) NOT NULL,
    [NombreCorto]          VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([AreaDeFormacionID] ASC),
    CONSTRAINT [AK_AcAreaDeFormacion_AreaDeFormacionClave] UNIQUE NONCLUSTERED ([AreaDeFormacionClave] ASC),
    CONSTRAINT [AK_AcAreaDeFormacion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcAreaDeFormacion_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);

