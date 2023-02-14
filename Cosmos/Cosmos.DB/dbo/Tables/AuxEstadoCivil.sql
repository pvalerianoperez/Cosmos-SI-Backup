CREATE TABLE [dbo].[AuxEstadoCivil] (
    [AuxEstadoCivilID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxEstadoCivilClave] VARCHAR (6)  NOT NULL,
    [Nombre]              VARCHAR (30) NOT NULL,
    [NombreCorto]         VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_AuxEstadoCivil] PRIMARY KEY CLUSTERED ([AuxEstadoCivilID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EstadoCivil]
    ON [dbo].[AuxEstadoCivil]([AuxEstadoCivilClave] ASC);

