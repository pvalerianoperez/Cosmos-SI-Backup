CREATE TABLE [dbo].[UsuarioEstatusDocumentoPermiso] (
    [UsuarioEstatusDocumentoPermisoID] INT   IDENTITY (1, 1) NOT NULL,
    [UsuarioID]                        INT   NOT NULL,
    [EstatusDocumentoID]               INT   NOT NULL,
    [CentroCostoID]                    INT   NULL,
    [AreaID]                           INT   NULL,
    [EmpresaID]                        INT   NULL,
    [AlmacenID]                        INT   NULL,
    [SucursalID]                       INT   NULL,
    [Monto]                            MONEY NULL,
    CONSTRAINT [PK_UsuarioEstatusDocumentoPermiso] PRIMARY KEY CLUSTERED ([UsuarioEstatusDocumentoPermisoID] ASC),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[Almacen] ([AlmacenID]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_Area] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaId]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_CentroCosto] FOREIGN KEY ([CentroCostoID]) REFERENCES [dbo].[CentroCosto] ([CentroCostoID]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_EstatusDocumento] FOREIGN KEY ([EstatusDocumentoID]) REFERENCES [dbo].[EstatusDocumento] ([EstatusDocumentoID]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_SistemaUsuario] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SistemaUsuario] ([UsuarioID]),
    CONSTRAINT [FK_UsuarioEstatusDocumentoPermiso_Sucursal] FOREIGN KEY ([SucursalID]) REFERENCES [dbo].[Sucursal] ([SucursalID])
);

