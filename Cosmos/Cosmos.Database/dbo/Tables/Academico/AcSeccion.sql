CREATE TABLE [dbo].[AcSeccion] (
    [SeccionID]        INT           NOT NULL IDENTITY,
    [SeccionClave]     VARCHAR (6)   NULL,
    [Nombre]           VARCHAR (80)  NOT NULL,
    [NombreCorto]      VARCHAR (15)  NULL,
    [Descripcion]      VARCHAR (150) NULL,
    [NivelEducativoID] INT           NOT NULL,
    CONSTRAINT [PK_AcSeccion] PRIMARY KEY CLUSTERED ([SeccionID] ASC), 
    CONSTRAINT [FK_AcSeccion_AcNivelEducativo] FOREIGN KEY ([NivelEducativoID]) REFERENCES [AcNivelEducativo]([NivelEducativoID]), 
    CONSTRAINT [AK_AcSeccion_Nombre] UNIQUE ([Nombre])
);

