CREATE TABLE [dbo].[CfgTipoProducto] (
    [CfgTipoProductoID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoProductoClave] VARCHAR (4)  NOT NULL,
    [Nombre]               VARCHAR (40) NOT NULL,
    [NombreCorto]          VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_CfgTipoProducto] PRIMARY KEY CLUSTERED ([CfgTipoProductoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoProducto]
    ON [dbo].[CfgTipoProducto]([CfgTipoProductoClave] ASC);

