CREATE TABLE [dbo].[CoTipoPresupuestoBase] (
    [CoTipoPresupuestoBaseID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoTipoPresupuestoBaseClave] VARCHAR (10) NOT NULL,
    [Nombre]                     VARCHAR (80) NOT NULL,
    [NombreCorto]                VARCHAR (12) NOT NULL,
    [CoTipoConstruccionID]       INT          NOT NULL,
    CONSTRAINT [PK_CoTipoPresupuestoBase] PRIMARY KEY CLUSTERED ([CoTipoPresupuestoBaseID] ASC),
    CONSTRAINT [FK_CoTipoPresupuestoBase_CoTipoConstruccion] FOREIGN KEY ([CoTipoConstruccionID]) REFERENCES [dbo].[CoTipoConstruccion] ([CoTipoConstruccionID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoTipoPresupuestoBase_CoTipoPresupuestoBaseClave]
    ON [dbo].[CoTipoPresupuestoBase]([CoTipoPresupuestoBaseClave] ASC);

