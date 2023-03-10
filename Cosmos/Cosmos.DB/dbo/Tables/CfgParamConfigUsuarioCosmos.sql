CREATE TABLE [dbo].[CfgParamConfigUsuarioCosmos] (
    [CfgParamConfigUsuarioCosmosID] INT          IDENTITY (1, 1) NOT NULL,
    [ComparteProveedor]             CHAR (1)     NOT NULL,
    [TextoArea]                     VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoAreas]                    VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoAreaAlias]                VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoAreasAlias]               VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoAreasPrefijo]             VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [TextoAreaPrefijo]              VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [TextoCentroCosto]              VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoCentrosCosto]             VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoCentroCostoAlias]         VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoCentrosCostoAlias]        VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoCentroCostoPrefijo]       VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [TextoCentrosCostoPrefijo]      VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [TextoSucursal]                 VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoSucursales]               VARCHAR (50) DEFAULT (' ') NOT NULL,
    [TextoSucursalAlias]            VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoSucursalesAlias]          VARCHAR (15) DEFAULT (' ') NOT NULL,
    [TextoSucursalPrefijo]          VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [TextoSucursalesPrefijo]        VARCHAR (5)  DEFAULT (' ') NOT NULL,
    [ProductoClaveAutomatico]       CHAR (1)     NOT NULL,
    [ProductoClaveDigitos]          TINYINT      NOT NULL,
    [ProveedorClaveAutomatico]      CHAR (1)     NOT NULL,
    [ProveedorClaveDigitos]         TINYINT      NOT NULL,
    [ClienteClaveAutomatico]        CHAR (1)     NOT NULL,
    [ClienteClaveDigitos]           TINYINT      NOT NULL,
    [ProductoUltimaClave]           INT          NOT NULL,
    [ProveedorUltimaClave]          INT          NOT NULL,
    [ClienteUltimaClave]            INT          NOT NULL,
    CONSTRAINT [PK_CfgParamConfigUsuarioCosmos] PRIMARY KEY CLUSTERED ([CfgParamConfigUsuarioCosmosID] ASC)
);

