CREATE TABLE [dbo].[BcoSucursal] (
    [BcoSucursalID]    INT          IDENTITY (1, 1) NOT NULL,
    [BcoSucursalClave] VARCHAR (5)  NOT NULL,
    [AuxBancoID]       INT          NOT NULL,
    [Nombre]           VARCHAR (60) NOT NULL,
    [NombreCorto]      VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_BcoSucursal] PRIMARY KEY CLUSTERED ([BcoSucursalID] ASC),
    CONSTRAINT [FK_BcoSucursal_AuxBanco] FOREIGN KEY ([AuxBancoID]) REFERENCES [dbo].[AuxBanco] ([AuxBancoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BcoSucursal_AuxBancoID_BcoSucursalClave]
    ON [dbo].[BcoSucursal]([AuxBancoID] ASC, [BcoSucursalClave] ASC);

