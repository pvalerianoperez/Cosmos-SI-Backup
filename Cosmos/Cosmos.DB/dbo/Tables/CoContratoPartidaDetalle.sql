CREATE TABLE [dbo].[CoContratoPartidaDetalle] (
    [CoContratoPartidaDetalleID] INT             IDENTITY (1, 1) NOT NULL,
    [CoContratoID]               INT             NOT NULL,
    [CoPartidaDetalleID]         INT             NOT NULL,
    [Cantidad]                   DECIMAL (18, 6) NOT NULL,
    [Precio]                     DECIMAL (18, 6) NOT NULL,
    [Adicional]                  VARCHAR (500)   NOT NULL,
    [SustituirConAdicional]      BIT             NOT NULL,
    [CfgEstatusDocumentoID]      INT             NOT NULL,
    CONSTRAINT [PK_CoContratoPartidaDetalle] PRIMARY KEY CLUSTERED ([CoContratoPartidaDetalleID] ASC)
);

