CREATE TABLE [dbo].[PpalSucursal] (
    [PpalSucursalID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalSucursalClave] VARCHAR (8)  NOT NULL,
    [Nombre]            VARCHAR (70) NOT NULL,
    [NombreCorto]       VARCHAR (10) NOT NULL,
    [EmpresaID]         INT          NOT NULL,
    [EspDomicilioID]    INT          NOT NULL,
    CONSTRAINT [PK_sucursales] PRIMARY KEY CLUSTERED ([PpalSucursalID] ASC),
    CONSTRAINT [FK_PpalSucursal_Domicilio] FOREIGN KEY ([EspDomicilioID]) REFERENCES [dbo].[EspDomicilio] ([EspDomicilioID]),
    CONSTRAINT [FK_PpalSucursal_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Sucursal_EmpresaID_SucursalClave]
    ON [dbo].[PpalSucursal]([EmpresaID] ASC, [PpalSucursalClave] ASC);

