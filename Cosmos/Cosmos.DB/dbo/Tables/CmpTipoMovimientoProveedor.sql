CREATE TABLE [dbo].[CmpTipoMovimientoProveedor] (
    [CmpTipoMovimientoProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CmpTipoMovimientoProveedorClave] VARCHAR (10) NOT NULL,
    [Nombre]                          VARCHAR (50) NOT NULL,
    [NombreCorto]                     VARCHAR (20) NOT NULL,
    [NaturalezaID]                    INT          NOT NULL,
    CONSTRAINT [PK_CmpTipoMovimientoProveedor] PRIMARY KEY CLUSTERED ([CmpTipoMovimientoProveedorID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpTipoMovimientoProveedor_CmpTipoMovimientoProveedorClave]
    ON [dbo].[CmpTipoMovimientoProveedor]([CmpTipoMovimientoProveedorClave] ASC);

