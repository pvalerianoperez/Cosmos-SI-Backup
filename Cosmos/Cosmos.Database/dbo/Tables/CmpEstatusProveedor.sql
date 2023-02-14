CREATE TABLE [dbo].[CmpEstatusProveedor] (
    [CmpEstatusProveedorID]    INT          IDENTITY (1, 1) NOT NULL,
    [CmpEstatusProveedorClave] VARCHAR (6)  NULL,
    [Nombre]                   VARCHAR (40) NOT NULL,
    [NombreCorto]              VARCHAR (10) NOT NULL,
    [EstatusPersonaID]         INT          NULL,
    CONSTRAINT [PK_CmpEstatusProveedor] PRIMARY KEY CLUSTERED ([CmpEstatusProveedorID] ASC),
    CONSTRAINT [FK_CmpEstatusProveedor_SistemaEstatusPersona] FOREIGN KEY ([EstatusPersonaID]) REFERENCES [dbo].[SistemaEstatusPersona] ([EstatusPersonaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CmpEstatusProveedor_CmpEstatusProveedorClave]
    ON [dbo].[CmpEstatusProveedor]([CmpEstatusProveedorClave] ASC);

