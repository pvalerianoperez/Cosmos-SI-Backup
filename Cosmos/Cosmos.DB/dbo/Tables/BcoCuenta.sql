CREATE TABLE [dbo].[BcoCuenta] (
    [BcoCuentaID]   INT          IDENTITY (1, 1) NOT NULL,
    [Clabe]         DECIMAL (18) NOT NULL,
    [Cuenta]        DECIMAL (18) NOT NULL,
    [Tarjeta]       DECIMAL (16) NOT NULL,
    [BcoSucursalID] INT          NOT NULL,
    CONSTRAINT [PK_BcoCuenta] PRIMARY KEY CLUSTERED ([BcoCuentaID] ASC),
    CONSTRAINT [FK_BcoCuenta_BcoSucursal] FOREIGN KEY ([BcoSucursalID]) REFERENCES [dbo].[BcoSucursal] ([BcoSucursalID])
);

