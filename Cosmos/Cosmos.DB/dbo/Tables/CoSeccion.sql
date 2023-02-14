CREATE TABLE [dbo].[CoSeccion] (
    [CoSeccionID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoSeccionClave] VARCHAR (10) NOT NULL,
    [Nombre]         VARCHAR (80) NOT NULL,
    [NombreCorto]    VARCHAR (12) NOT NULL,
    [CoProyectoID]   INT          NOT NULL,
    [ManejaElemento] BIT          NOT NULL,
    CONSTRAINT [PK_CoSeccion] PRIMARY KEY CLUSTERED ([CoSeccionID] ASC),
    CONSTRAINT [FK_CoSeccion_CoProyecto] FOREIGN KEY ([CoProyectoID]) REFERENCES [dbo].[CoProyecto] ([CoProyectoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoSeccion_CoProyectoID_NombreCorto]
    ON [dbo].[CoSeccion]([CoProyectoID] ASC, [NombreCorto] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoSeccion_CoProyectoID_Nombre]
    ON [dbo].[CoSeccion]([CoProyectoID] ASC, [Nombre] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoSeccion_CoProyectoID_CoSeccionClave]
    ON [dbo].[CoSeccion]([CoProyectoID] ASC, [CoSeccionClave] ASC);

