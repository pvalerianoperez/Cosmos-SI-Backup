CREATE TABLE [dbo].[SegUsuarioEstatusDocumento] (
    [SegUsuarioEstatusDocumentoID] INT   IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]                 INT   NOT NULL,
    [CfgEstatusDocumentoID]        INT   NOT NULL,
    [PpalCentroCostoID]            INT   NULL,
    [PpalAreaID]                   INT   NULL,
    [EmpresaID]                    INT   NULL,
    [PpalAlmacenID]                INT   NULL,
    [PpalSucursalID]               INT   NULL,
    [Monto]                        MONEY NULL,
    CONSTRAINT [PK_SegUsuarioEstatusDocumentoPermiso] PRIMARY KEY CLUSTERED ([SegUsuarioEstatusDocumentoID] ASC),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_Almacen] FOREIGN KEY ([PpalAlmacenID]) REFERENCES [dbo].[PpalAlmacen] ([PpalAlmacenID]),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_CfgEstatusDocumento] FOREIGN KEY ([CfgEstatusDocumentoID]) REFERENCES [dbo].[CfgEstatusDocumento] ([CfgEstatusDocumentoID]),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]),
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE,
    CONSTRAINT [FK_SegUsuarioEstatusDocumento_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegUsuarioEstatusDocumento]
    ON [dbo].[SegUsuarioEstatusDocumento]([SegUsuarioID] ASC, [CfgEstatusDocumentoID] ASC, [EmpresaID] ASC, [PpalSucursalID] ASC, [PpalAreaID] ASC, [PpalAlmacenID] ASC, [PpalCentroCostoID] ASC);

