CREATE TABLE [dbo].[AcSeccion] (
    [SeccionID]        INT           IDENTITY (1, 1) NOT NULL,
    [SeccionClave]     VARCHAR (6)   NULL,
    [Nombre]           VARCHAR (80)  NOT NULL,
    [NombreCorto]      VARCHAR (15)  NULL,
    [Descripcion]      VARCHAR (150) NULL,
    [NivelEducativoID] INT           NOT NULL,
    CONSTRAINT [PK_AcSeccion] PRIMARY KEY CLUSTERED ([SeccionID] ASC),
    CONSTRAINT [FK_AcSeccion_AcNivelEducativo] FOREIGN KEY ([NivelEducativoID]) REFERENCES [dbo].[AcNivelEducativo] ([NivelEducativoID]),
    CONSTRAINT [AK_AcSeccion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

