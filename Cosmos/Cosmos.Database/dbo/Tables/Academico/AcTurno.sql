CREATE TABLE [dbo].[AcTurno] (
    [TurnoID]     INT           NOT NULL IDENTITY,
    [TurnoClave]  VARCHAR (6)   NULL,
    [Nombre]      VARCHAR (80)  NULL,
    [NombreCorto] VARCHAR (15)  NULL,
    [HoraInicio]  SMALLINT NULL,
    [HoraFinal]   SMALLINT  NULL, 
    CONSTRAINT [PK_AcTurnos] PRIMARY KEY ([TurnoID])
);

