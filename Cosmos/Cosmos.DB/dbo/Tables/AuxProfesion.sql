CREATE TABLE [dbo].[AuxProfesion] (
    [AuxProfesionID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxProfesionClave] VARCHAR (8)  NOT NULL,
    [Nombre]            VARCHAR (60) NOT NULL,
    [NombreCorto]       VARCHAR (20) NOT NULL,
    [Tratamiento]       VARCHAR (6)  NOT NULL,
    CONSTRAINT [PK_Auxprofesion] PRIMARY KEY CLUSTERED ([AuxProfesionID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Profesion_ProfesionClave]
    ON [dbo].[AuxProfesion]([AuxProfesionClave] ASC);

