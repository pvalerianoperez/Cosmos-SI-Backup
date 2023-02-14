CREATE TABLE [dbo].[CmpTipoProveedor] (
    [CmpTipoProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CmpTipoProveedorClave] VARCHAR (4)  NOT NULL,
    [Nombre]                VARCHAR (50) NOT NULL,
    [NombreCorto]           VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_CmpTipoProveedor] PRIMARY KEY CLUSTERED ([CmpTipoProveedorID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpTipoProveedor_CmpTipoProveedorClave]
    ON [dbo].[CmpTipoProveedor]([CmpTipoProveedorClave] ASC);

