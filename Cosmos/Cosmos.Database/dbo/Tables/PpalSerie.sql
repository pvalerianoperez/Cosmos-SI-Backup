CREATE TABLE [dbo].[PpalSerie] (
    [PpalSerieID]     INT          IDENTITY (1, 1) NOT NULL,
    [TipoDocumentoID] INT          NOT NULL,
    [PpalSerieClave]  VARCHAR (10) NOT NULL,
    [FolioInicial]    INT          NOT NULL,
    [FolioFinal]      INT          NOT NULL,
    [UltimoFolio]     INT          NOT NULL,
    [Estatus]         BIT          NOT NULL,
    [Predeterminado]  BIT          NOT NULL,
    [PpalSucursalID]  INT          NULL,
    CONSTRAINT [PK_PpalSerieID] PRIMARY KEY CLUSTERED ([PpalSerieID] ASC),
    CONSTRAINT [FK_PpalSerie_PpalSucursal] FOREIGN KEY ([PpalSucursalID]) REFERENCES [dbo].[PpalSucursal] ([PpalSucursalID]) ON DELETE SET NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalSerie_PpalSucursalID_TipoDocumentoID_PpalSerieClave]
    ON [dbo].[PpalSerie]([PpalSucursalID] ASC, [TipoDocumentoID] ASC, [PpalSerieClave] ASC);

