CREATE TABLE [dbo].[PpalRepresentanteProveedor] (
    [PpalRepresentanteProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID]                 INT          NOT NULL,
    [EspPersonaID]                    INT          NOT NULL,
    [ProfesionID]                     INT          NOT NULL,
    [CmpTipoRepresentanteProveedorID] INT          NOT NULL,
    [Predeterminado]                  BIT          NOT NULL,
    [Puesto]                          VARCHAR (60) NOT NULL,
    CONSTRAINT [PK_PpalRepresentanteProveedorID] PRIMARY KEY CLUSTERED ([PpalRepresentanteProveedorID] ASC),
    CONSTRAINT [FK_PpalRepresentanteProveedor_AuxProfesion] FOREIGN KEY ([ProfesionID]) REFERENCES [dbo].[AuxProfesion] ([AuxProfesionID]),
    CONSTRAINT [FK_PpalRepresentanteProveedor_CmpTipoRepresentanteProveedor] FOREIGN KEY ([CmpTipoRepresentanteProveedorID]) REFERENCES [dbo].[CmpTipoRepresentanteProveedor] ([CmpTipoRepresentanteProveedorID]),
    CONSTRAINT [FK_PpalRepresentanteProveedor_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID]),
    CONSTRAINT [FK_PpalRepresentanteProveedor_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID])
);

