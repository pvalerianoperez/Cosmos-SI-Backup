CREATE TABLE [dbo].[CoPartida] (
    [CoPartidaID]                INT          IDENTITY (1, 1) NOT NULL,
    [PadreID]                    INT          NULL,
    [CoPartidaClave]             VARCHAR (5)  NOT NULL,
    [Nombre]                     VARCHAR (40) NOT NULL,
    [NombreCorto]                VARCHAR (10) NOT NULL,
    [CoTipoPresupuestoID]        INT          NOT NULL,
    [PpalAreaIDInicio]           INT          DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoIDInicio] INT          DEFAULT ((0)) NOT NULL,
    [AplicaIVA]                  CHAR (1)     NOT NULL,
    [CoTipoConstruccionID]       INT          NOT NULL,
    CONSTRAINT [PKCoPartida] PRIMARY KEY CLUSTERED ([CoPartidaID] ASC),
    CONSTRAINT [FK_CoPartida_ConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoIDInicio]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CoPartida_CoPartida] FOREIGN KEY ([PadreID]) REFERENCES [dbo].[CoPartida] ([CoPartidaID]),
    CONSTRAINT [FK_CoPartida_CoTipoConstruccion] FOREIGN KEY ([CoTipoConstruccionID]) REFERENCES [dbo].[CoTipoConstruccion] ([CoTipoConstruccionID]),
    CONSTRAINT [FK_CoPartida_CoTipoPresupuesto] FOREIGN KEY ([CoTipoPresupuestoID]) REFERENCES [dbo].[CoTipoPresupuesto] ([CoTipoPresupuestoID]),
    CONSTRAINT [FK_CoPartida_PpalArea] FOREIGN KEY ([PpalAreaIDInicio]) REFERENCES [dbo].[PpalArea] ([PpalAreaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoPartida_CoTipoPresupuestoID_CoPartidaClave]
    ON [dbo].[CoPartida]([CoTipoPresupuestoID] ASC, [CoPartidaClave] ASC);

