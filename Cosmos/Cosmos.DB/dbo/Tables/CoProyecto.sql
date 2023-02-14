CREATE TABLE [dbo].[CoProyecto] (
    [CoProyectoID]          INT           IDENTITY (1, 1) NOT NULL,
    [PpalSucursalID]        INT           NOT NULL,
    [CoProyectoClave]       VARCHAR (12)  NOT NULL,
    [Nombre]                VARCHAR (150) NOT NULL,
    [NombreCorto]           VARCHAR (40)  NOT NULL,
    [NivelPartidaInicio]    TINYINT       NOT NULL,
    [PpalCentroCostoID]     INT           NOT NULL,
    [ManejaElementoInicio]  BIT           NOT NULL,
    [NivelCalendarioInicio] TINYINT       NOT NULL,
    [FechaAlta]             DATE          DEFAULT (getdate()) NOT NULL,
    [EspCP]                 INT           DEFAULT ((0)) NOT NULL,
    [Inscripcion]           VARCHAR (30)  DEFAULT ('') NOT NULL,
    [Libro]                 VARCHAR (30)  DEFAULT ('') NOT NULL,
    [Seccion]               VARCHAR (30)  DEFAULT ('') NOT NULL,
    [TipoCapturaAvance]     TINYINT       DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CoProyecto] PRIMARY KEY CLUSTERED ([CoProyectoID] ASC),
    CONSTRAINT [FK_CoProyecto_EspCP] FOREIGN KEY ([EspCP]) REFERENCES [dbo].[EspCP] ([EspCP]),
    CONSTRAINT [FK_CoProyecto_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_CoProyecto_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoProyecto_PpalSucursalID_ProyectoClave]
    ON [dbo].[CoProyecto]([PpalSucursalID] ASC, [CoProyectoClave] ASC);

