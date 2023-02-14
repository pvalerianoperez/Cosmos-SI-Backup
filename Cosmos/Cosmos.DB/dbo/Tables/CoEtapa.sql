CREATE TABLE [dbo].[CoEtapa] (
    [CoEtapaID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoEtapaClave] VARCHAR (10) NOT NULL,
    [Nombre]       VARCHAR (60) NOT NULL,
    [NombreCorto]  VARCHAR (10) NOT NULL,
    [CoProyectoID] INT          NOT NULL,
    [FechaInicial] DATE         NOT NULL,
    [FechaFinal]   DATE         NOT NULL,
    CONSTRAINT [PK_CoEtapa] PRIMARY KEY CLUSTERED ([CoEtapaID] ASC),
    CONSTRAINT [FK_CoEtapa_CoProyecto] FOREIGN KEY ([CoProyectoID]) REFERENCES [dbo].[CoProyecto] ([CoProyectoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoEtapa_CoProyectoID_CoEtapaClave]
    ON [dbo].[CoEtapa]([CoProyectoID] ASC, [CoEtapaClave] ASC);

