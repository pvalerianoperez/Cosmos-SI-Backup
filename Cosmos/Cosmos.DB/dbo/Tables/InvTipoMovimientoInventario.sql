CREATE TABLE [dbo].[InvTipoMovimientoInventario] (
    [InvTipoMovimientoInventarioID]    INT          IDENTITY (1, 1) NOT NULL,
    [InvTipoMovimientoInventarioClave] VARCHAR (10) NOT NULL,
    [Nombre]                           VARCHAR (50) NOT NULL,
    [NombreCorto]                      VARCHAR (20) NOT NULL,
    [EntradaSalida]                    CHAR (1)     NOT NULL,
    CONSTRAINT [PK_InvTipoMovimientoInventario] PRIMARY KEY CLUSTERED ([InvTipoMovimientoInventarioID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvTipoMovimientoInventario_InvTipoMovimientoInventarioClave]
    ON [dbo].[InvTipoMovimientoInventario]([InvTipoMovimientoInventarioClave] ASC);

