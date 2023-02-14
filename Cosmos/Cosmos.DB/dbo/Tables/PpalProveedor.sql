CREATE TABLE [dbo].[PpalProveedor] (
    [PpalProveedorID]    INT      IDENTITY (1, 1) NOT NULL,
    [EspPersonaID]       INT      NOT NULL,
    [CmpTipoProveedorID] INT      NOT NULL,
    [AuxGiroEmpresaID]   INT      NOT NULL,
    [AuxMedioContactoID] INT      NOT NULL,
    [AuxVinculoID]       INT      NOT NULL,
    [AplicaRetenciones]  CHAR (1) CONSTRAINT [DF_PpalProveedor_AplicaRetenciones] DEFAULT ('N') NOT NULL,
    CONSTRAINT [PK_PpalProveedorID] PRIMARY KEY CLUSTERED ([PpalProveedorID] ASC),
    CONSTRAINT [FK_PpalProveedor_AuxMedioContacto] FOREIGN KEY ([AuxMedioContactoID]) REFERENCES [dbo].[AuxMedioContacto] ([AuxMedioContactoID]),
    CONSTRAINT [FK_PpalProveedor_AuxVinculo] FOREIGN KEY ([AuxVinculoID]) REFERENCES [dbo].[AuxVinculo] ([AuxVinculoID]),
    CONSTRAINT [FK_PpalProveedor_CmpTipoProveedor] FOREIGN KEY ([CmpTipoProveedorID]) REFERENCES [dbo].[CmpTipoProveedor] ([CmpTipoProveedorID]),
    CONSTRAINT [FK_PpalProveedor_GiroEmpresa] FOREIGN KEY ([AuxGiroEmpresaID]) REFERENCES [dbo].[AuxGiroEmpresa] ([AuxGiroEmpresaID]),
    CONSTRAINT [FK_PpalProveedor_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID])
);

