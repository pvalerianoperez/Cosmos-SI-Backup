CREATE TABLE [dbo].[BcoTipoMovimiento] (
    [BcoTipoMovimientoID]    INT          IDENTITY (1, 1) NOT NULL,
    [BcoTipoMovimientoClave] VARCHAR (10) NOT NULL,
    [Nombre]                 VARCHAR (50) NOT NULL,
    [NombreCorto]            VARCHAR (15) NOT NULL,
    [NaturalezaID]           INT          NOT NULL,
    CONSTRAINT [PK_BcoTipoMovimiento] PRIMARY KEY CLUSTERED ([BcoTipoMovimientoID] ASC)
);

