CREATE TABLE [dbo].[CfgFamiliaProducto] (
    [CfgFamiliaProductoID] INT          IDENTITY (1, 1) NOT NULL,
    [PadreID]              INT          NULL,
    [CfgFamiliaClave]      VARCHAR (5)  NOT NULL,
    [FamiliaClavePadre]    VARCHAR (5)  NOT NULL,
    [Nombre]               VARCHAR (40) NOT NULL,
    [NombreCorto]          VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_Cfgfamiliaproducto] PRIMARY KEY CLUSTERED ([CfgFamiliaProductoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FamiliaProducto_FamiliaClavePadre_FamiliaClave]
    ON [dbo].[CfgFamiliaProducto]([FamiliaClavePadre] ASC, [CfgFamiliaClave] ASC);

