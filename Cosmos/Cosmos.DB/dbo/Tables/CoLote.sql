CREATE TABLE [dbo].[CoLote] (
    [CoLoteID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoLoteClave] VARCHAR (10) NOT NULL,
    [Nombre]      VARCHAR (80) NOT NULL,
    [NombreCorto] VARCHAR (12) NOT NULL,
    [CoSeccionID] INT          NOT NULL,
    CONSTRAINT [PK_CoLote] PRIMARY KEY CLUSTERED ([CoLoteID] ASC),
    CONSTRAINT [FK_CoLote_CoSeccion] FOREIGN KEY ([CoSeccionID]) REFERENCES [dbo].[CoSeccion] ([CoSeccionID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoLote_CoSeccionID_NombreCorto]
    ON [dbo].[CoLote]([CoSeccionID] ASC, [NombreCorto] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoLote_CoSeccionID_Nombre]
    ON [dbo].[CoLote]([CoSeccionID] ASC, [Nombre] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoLote_CoSeccionID_CoLoteClave]
    ON [dbo].[CoLote]([CoSeccionID] ASC, [CoLoteClave] ASC);

