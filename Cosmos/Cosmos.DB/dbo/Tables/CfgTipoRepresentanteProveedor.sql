CREATE TABLE [dbo].[CfgTipoRepresentanteProveedor] (
    [CfgTipoRepresentanteProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoRepresentanteProveedorClave] VARCHAR (10) NOT NULL,
    [Nombre]                             VARCHAR (60) NOT NULL,
    [NombreCorto]                        VARCHAR (10) NOT NULL,
    [TipoRepresentanteProveedorID]       INT          NOT NULL,
    CONSTRAINT [PK_CfgTipoRepresentanteProveedorID] PRIMARY KEY CLUSTERED ([CfgTipoRepresentanteProveedorID] ASC),
    CONSTRAINT [FK_CfgTipoRepresentanteProveedor_SistemaTipoRepresentanteProveedor] FOREIGN KEY ([TipoRepresentanteProveedorID]) REFERENCES [dbo].[SistemaTipoRepresentanteProveedor] ([TipoRepresentanteProveedorID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgTipoRepresentanteProveedor]
    ON [dbo].[CfgTipoRepresentanteProveedor]([CfgTipoRepresentanteProveedorClave] ASC);

