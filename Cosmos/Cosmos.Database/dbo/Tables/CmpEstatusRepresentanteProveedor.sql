CREATE TABLE [dbo].[CmpEstatusRepresentanteProveedor] (
    [CmpEstatusRepresentanteProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CmpEstatusRepresentanteProveedorClave] VARCHAR (6)  NULL,
    [Nombre]                                VARCHAR (40) NOT NULL,
    [NombreCorto]                           VARCHAR (10) NOT NULL,
    [EstatusPersonaID]                      INT          NULL,
    CONSTRAINT [PK_CmpEstatusRepresentanteProveedor] PRIMARY KEY CLUSTERED ([CmpEstatusRepresentanteProveedorID] ASC),
    CONSTRAINT [FK_CmpEstatusRepresentanteProveedor_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpEstatusRepresentanteProveedor_CmpEstatusRepresentanteProveedorClave]
    ON [dbo].[CmpEstatusRepresentanteProveedor]([CmpEstatusRepresentanteProveedorClave] ASC);

