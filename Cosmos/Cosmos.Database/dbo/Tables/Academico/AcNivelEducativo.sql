CREATE TABLE [dbo].[AcNivelEducativo] (
    [NivelEducativoID]    INT          NOT NULL IDENTITY,
    [NivelEducativoClave] VARCHAR (6)  NULL,
    [Nombre]              VARCHAR (80) NOT NULL,
    [NombreCorto]         VARCHAR (15) NULL,
    CONSTRAINT [PK_AcNivelEducativo] PRIMARY KEY CLUSTERED ([NivelEducativoID] ASC), 
    CONSTRAINT [AK_AcNivelEducativo_NivelEducativoClave] UNIQUE ([NivelEducativoClave]),
    CONSTRAINT [AK_AcNivelEducativo_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_AcNivelEducativo_NombreCorto] UNIQUE ([NombreCorto])
);

