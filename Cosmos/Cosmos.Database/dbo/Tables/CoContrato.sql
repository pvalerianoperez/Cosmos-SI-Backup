CREATE TABLE [dbo].[CoContrato] (
    [CoContratoID]    INT           NOT NULL,
    [CoContratoClave] VARCHAR (30)  NOT NULL,
    [Nombre]          VARCHAR (80)  NOT NULL,
    [NombreCorto]     VARCHAR (15)  NOT NULL,
    [CoProyectoID]    INT           NOT NULL,
    [PpalProveedorID] INT           NOT NULL,
    [FechaAlta]       DATE          NOT NULL,
    [FechaInicio]     DATE          NOT NULL,
    [FechaFin]        DATE          NOT NULL,
    [TipoContrato]    CHAR (1)      NOT NULL,
    [Comentarios]     VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_CoContrato] PRIMARY KEY CLUSTERED ([CoContratoID] ASC),
    CONSTRAINT [FK_CoContrato_CoProyecto] FOREIGN KEY ([CoProyectoID]) REFERENCES [dbo].[CoProyecto] ([CoProyectoID]),
    CONSTRAINT [FK_CoContrato_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoContrato_CoProyectoID_CoContratoClave]
    ON [dbo].[CoContrato]([CoProyectoID] ASC, [CoContratoClave] ASC);

