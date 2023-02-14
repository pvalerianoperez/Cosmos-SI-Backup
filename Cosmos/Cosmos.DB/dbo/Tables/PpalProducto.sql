CREATE TABLE [dbo].[PpalProducto] (
    [PpalProductoID]       INT             IDENTITY (1, 1) NOT NULL,
    [MarcaID]              INT             NOT NULL,
    [Nombre]               NVARCHAR (100)  NOT NULL,
    [NombreCorto]          NVARCHAR (20)   NOT NULL,
    [AuxUnidadID]          INT             NOT NULL,
    [ClaseProductoID]      INT             NOT NULL,
    [CfgTipoProductoID]    INT             NOT NULL,
    [NivelProductoID]      INT             NOT NULL,
    [MetodoCosteoID]       INT             NOT NULL,
    [ManejaLotes]          CHAR (1)        NOT NULL,
    [ManejaSeries]         CHAR (1)        NOT NULL,
    [Reorden]              DECIMAL (18, 6) NOT NULL,
    [CfgFamiliaProductoID] INT             NOT NULL,
    [EstatusProductoID]    INT             NOT NULL,
    [Maximo]               DECIMAL (18, 6) NOT NULL,
    [Minimo]               DECIMAL (18, 6) NOT NULL,
    [CostoPromedio]        DECIMAL (18, 2) NOT NULL,
    [UltimoCosto]          DECIMAL (18, 2) NOT NULL,
    [PpalProductoClave]    VARCHAR (20)    NOT NULL,
    [EmpresaID]            INT             NULL,
    [CfgTasaIVAID]         INT             CONSTRAINT [DF_PpalProducto_CfgTasaIVAID] DEFAULT ((0)) NOT NULL,
    [ExentoIVA]            CHAR (1)        CONSTRAINT [DF_PpalProducto_ExcentoIVA] DEFAULT ('N') NOT NULL,
    CONSTRAINT [PK_PpalProductoID] PRIMARY KEY CLUSTERED ([PpalProductoID] ASC),
    CONSTRAINT [FK_PpalProducto_AuxMarca] FOREIGN KEY ([MarcaID]) REFERENCES [dbo].[AuxMarca] ([AuxMarcaID]),
    CONSTRAINT [FK_PpalProducto_AuxUnidad] FOREIGN KEY ([AuxUnidadID]) REFERENCES [dbo].[AuxUnidad] ([AuxUnidadID]),
    CONSTRAINT [FK_PpalProducto_CfgFamiliaProducto] FOREIGN KEY ([CfgFamiliaProductoID]) REFERENCES [dbo].[CfgFamiliaProducto] ([CfgFamiliaProductoID]),
    CONSTRAINT [FK_PpalProducto_CfgTipoProducto] FOREIGN KEY ([CfgTipoProductoID]) REFERENCES [dbo].[CfgTipoProducto] ([CfgTipoProductoID]),
    CONSTRAINT [FK_PpalProducto_SistemaClaseProducto] FOREIGN KEY ([ClaseProductoID]) REFERENCES [dbo].[SistemaClaseProducto] ([ClaseProductoID]),
    CONSTRAINT [FK_PpalProducto_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID]) ON DELETE SET NULL,
    CONSTRAINT [FK_PpalProducto_SistemaEstatusProducto] FOREIGN KEY ([EstatusProductoID]) REFERENCES [dbo].[SistemaEstatusProducto] ([EstatusProductoID]),
    CONSTRAINT [FK_PpalProducto_SistemaMetodoCosteo] FOREIGN KEY ([MetodoCosteoID]) REFERENCES [dbo].[SistemaMetodoCosteo] ([MetodoCosteoID]),
    CONSTRAINT [FK_PpalProducto_SistemaNivelProducto2] FOREIGN KEY ([NivelProductoID]) REFERENCES [dbo].[SistemaNivelProducto] ([NivelProductoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalProducto_EmpresaID_PpalProductoClave]
    ON [dbo].[PpalProducto]([EmpresaID] ASC, [PpalProductoClave] ASC);

