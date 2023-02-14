CREATE TABLE [dbo].[SistemaTipoRepresentanteProveedor] (
    [TipoRepresentanteProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [TipoRepresentanteProveedorClave] VARCHAR (4)  NOT NULL,
    [Nombre]                          VARCHAR (30) NOT NULL,
    [NombreCorto]                     VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_SistemaTipoRepresentanteProveedor] PRIMARY KEY CLUSTERED ([TipoRepresentanteProveedorID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoRepresentanteProveedor_TipoRepresentanteProveedorClave]
    ON [dbo].[SistemaTipoRepresentanteProveedor]([TipoRepresentanteProveedorClave] ASC);

