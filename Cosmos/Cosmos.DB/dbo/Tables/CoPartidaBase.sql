CREATE TABLE [dbo].[CoPartidaBase] (
    [CoPartidaBaseID]            INT          IDENTITY (1, 1) NOT NULL,
    [PadreID]                    INT          NULL,
    [CoPartidaBaseClave]         VARCHAR (5)  NOT NULL,
    [Nombre]                     VARCHAR (40) NOT NULL,
    [NombreCorto]                VARCHAR (10) NOT NULL,
    [CoTipoPresupuestoBaseID]    INT          NOT NULL,
    [PpalAreaIDInicio]           INT          DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoIDInicio] INT          DEFAULT ((0)) NOT NULL,
    [AplicaIVA]                  CHAR (1)     NOT NULL,
    [CoTipoConstruccionID]       INT          NOT NULL,
    CONSTRAINT [PKCoPartidaBase] PRIMARY KEY CLUSTERED ([CoPartidaBaseID] ASC),
    CONSTRAINT [FK_CoPartidaBase_ConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoIDInicio]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CoPartidaBase_CoPartidaBase] FOREIGN KEY ([PadreID]) REFERENCES [dbo].[CoPartidaBase] ([CoPartidaBaseID]),
    CONSTRAINT [FK_CoPartidaBase_CoTipoConstruccion] FOREIGN KEY ([CoTipoConstruccionID]) REFERENCES [dbo].[CoTipoConstruccion] ([CoTipoConstruccionID]),
    CONSTRAINT [FK_CoPartidaBase_CoTipoPresupuestoBase] FOREIGN KEY ([CoTipoPresupuestoBaseID]) REFERENCES [dbo].[CoTipoPresupuestoBase] ([CoTipoPresupuestoBaseID]),
    CONSTRAINT [FK_CoPartidaBase_PpalArea] FOREIGN KEY ([PpalAreaIDInicio]) REFERENCES [dbo].[PpalArea] ([PpalAreaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoPartidaBase_CoTipoPresupuestoBaseID_CoPartidaBaseClave]
    ON [dbo].[CoPartidaBase]([CoTipoPresupuestoBaseID] ASC, [CoPartidaBaseClave] ASC);

