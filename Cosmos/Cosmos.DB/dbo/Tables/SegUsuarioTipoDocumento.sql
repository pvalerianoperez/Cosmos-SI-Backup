CREATE TABLE [dbo].[SegUsuarioTipoDocumento] (
    [SegUsuarioTipoDocumentoPermisoID] INT   IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]                     INT   NOT NULL,
    [TipoDocumentoID]                  INT   NOT NULL,
    [PpalCentroCostoID]                INT   NOT NULL,
    [PpalAreaID]                       INT   NOT NULL,
    [EmpresaID]                        INT   NOT NULL,
    [PpalAlmacenID]                    INT   NOT NULL,
    [PpalSucursalID]                   INT   NOT NULL,
    [Preautoriza]                      BIT   NOT NULL,
    [PreautorizarMonto]                MONEY NOT NULL,
    [Autoriza]                         BIT   NOT NULL,
    [AutorizarMonto]                   MONEY NOT NULL,
    CONSTRAINT [PK_SegUsuarioTipoDocumentoPermiso] PRIMARY KEY CLUSTERED ([SegUsuarioTipoDocumentoPermisoID] ASC)
);

