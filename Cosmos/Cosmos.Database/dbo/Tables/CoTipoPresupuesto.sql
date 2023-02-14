CREATE TABLE [dbo].[CoTipoPresupuesto] (
    [CoTipoPresupuestoID]     INT          IDENTITY (1, 1) NOT NULL,
    [CoTipoPresupuestoClave]  VARCHAR (10) NOT NULL,
    [Nombre]                  VARCHAR (80) NOT NULL,
    [NombreCorto]             VARCHAR (12) NOT NULL,
    [CoProyectoID]            INT          NOT NULL,
    [NivelPartida]            TINYINT      NOT NULL,
    [NivelCalendario]         TINYINT      NOT NULL,
    [CfgEstatusDocumentoID]   INT          DEFAULT ((0)) NOT NULL,
    [CoTipoPresupuestoBaseID] INT          CONSTRAINT [DF_CoTipoPresupuesto_CoTipoPresupuestoBaseID] DEFAULT ((0)) NOT NULL,
    [CoTipoConstruccionID]    INT          NOT NULL,
    CONSTRAINT [PK_CoTipoPresupuesto] PRIMARY KEY CLUSTERED ([CoTipoPresupuestoID] ASC),
    CONSTRAINT [FK_CoTipoPresupuesto_CoProyecto] FOREIGN KEY ([CoProyectoID]) REFERENCES [dbo].[CoProyecto] ([CoProyectoID]),
    CONSTRAINT [FK_CoTipoPresupuesto_CoTipoConstruccion] FOREIGN KEY ([CoTipoConstruccionID]) REFERENCES [dbo].[CoTipoConstruccion] ([CoTipoConstruccionID]),
    CONSTRAINT [FK_CoTipoPresupuesto_CoTipoPresupuestoBase] FOREIGN KEY ([CoTipoPresupuestoBaseID]) REFERENCES [dbo].[CoTipoPresupuestoBase] ([CoTipoPresupuestoBaseID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoTipoPresupuesto_CoProyectoID_CoTipoPresupuestoClave]
    ON [dbo].[CoTipoPresupuesto]([CoProyectoID] ASC, [CoTipoPresupuestoClave] ASC);

