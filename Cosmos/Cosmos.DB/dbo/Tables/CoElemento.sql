CREATE TABLE [dbo].[CoElemento] (
    [CoElementoID]        INT          IDENTITY (1, 1) NOT NULL,
    [CoElementoClave]     VARCHAR (10) NOT NULL,
    [Nombre]              VARCHAR (80) NOT NULL,
    [NombreCorto]         VARCHAR (12) NOT NULL,
    [CoLoteID]            INT          NOT NULL,
    [CoTipoPresupuestoID] INT          NOT NULL,
    [CoModeloID]          INT          NOT NULL,
    [CoFachadaID]         INT          NOT NULL,
    [CoContratoIDActual]  INT          NULL,
    CONSTRAINT [PK_CoElemento] PRIMARY KEY CLUSTERED ([CoElementoID] ASC),
    CONSTRAINT [FK_CoElemento_CoContrato] FOREIGN KEY ([CoContratoIDActual]) REFERENCES [dbo].[CoContrato] ([CoContratoID]) ON DELETE SET NULL,
    CONSTRAINT [FK_CoElemento_CoFachada] FOREIGN KEY ([CoFachadaID]) REFERENCES [dbo].[CoFachada] ([CoFachadaID]),
    CONSTRAINT [FK_CoElemento_CoLote] FOREIGN KEY ([CoLoteID]) REFERENCES [dbo].[CoLote] ([CoLoteID]),
    CONSTRAINT [FK_CoElemento_CoModelo] FOREIGN KEY ([CoModeloID]) REFERENCES [dbo].[CoModelo] ([CoModeloID]),
    CONSTRAINT [FK_CoElemento_CoTipoPresupuesto] FOREIGN KEY ([CoTipoPresupuestoID]) REFERENCES [dbo].[CoTipoPresupuesto] ([CoTipoPresupuestoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoElemento_CoLoteID_NombreCorto]
    ON [dbo].[CoElemento]([CoLoteID] ASC, [NombreCorto] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoElemento_CoLoteID_Nombre]
    ON [dbo].[CoElemento]([CoLoteID] ASC, [Nombre] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoElemento_CoLoteID_CoElementoClave]
    ON [dbo].[CoElemento]([CoLoteID] ASC, [CoElementoClave] ASC);

