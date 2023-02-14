CREATE TABLE [dbo].[AcNivelEducativo] (
    [NivelEducativoID]    INT          IDENTITY (1, 1) NOT NULL,
    [NivelEducativoClave] VARCHAR (6)  NULL,
    [Nombre]              VARCHAR (80) NOT NULL,
    [NombreCorto]         VARCHAR (15) NULL,
    CONSTRAINT [PK_AcNivelEducativo] PRIMARY KEY CLUSTERED ([NivelEducativoID] ASC),
    CONSTRAINT [AK_AcNivelEducativo_NivelEducativoClave] UNIQUE NONCLUSTERED ([NivelEducativoClave] ASC),
    CONSTRAINT [AK_AcNivelEducativo_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcNivelEducativo_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);

