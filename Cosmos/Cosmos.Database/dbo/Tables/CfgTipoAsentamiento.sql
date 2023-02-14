CREATE TABLE [dbo].[CfgTipoAsentamiento] (
    [CfgTipoAsentamientoID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoAsentamientoClave] VARCHAR (3)  NOT NULL,
    [Nombre]                   VARCHAR (40) NOT NULL,
    [NombreCorto]              VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_CfgTipoAsentamiento] PRIMARY KEY CLUSTERED ([CfgTipoAsentamientoID] ASC)
);

