CREATE TABLE [dbo].[CmpTipoRepresentanteProveedor] (
    [CmpTipoRepresentanteProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CmpTipoRepresentanteProveedorClave] VARCHAR (5)  NOT NULL,
    [Nombre]                             VARCHAR (50) NOT NULL,
    [NombreCorto]                        VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_CmpTipoRepresentanteProveedor] PRIMARY KEY CLUSTERED ([CmpTipoRepresentanteProveedorID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpTipoRepresentanteProveedor_CmpTipoRepresentateProveedorClave]
    ON [dbo].[CmpTipoRepresentanteProveedor]([CmpTipoRepresentanteProveedorClave] ASC);

