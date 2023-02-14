CREATE TABLE [dbo].[PpalRepresentanteProveedorMail] (
    [PpalRepresentanteProveedorMailID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalRepresentanteProveedorID]     INT           NOT NULL,
    [Mail]                             VARCHAR (100) NOT NULL,
    [CfgTipoMailID]                    INT           NOT NULL,
    [Predeterminado]                   BIT           NOT NULL,
    [Comentarios]                      VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PpalRepresentanteProveedorMailID] PRIMARY KEY CLUSTERED ([PpalRepresentanteProveedorMailID] ASC),
    CONSTRAINT [FK_PpalRepresentanteProveedorMail_CfgTipoMail] FOREIGN KEY ([CfgTipoMailID]) REFERENCES [dbo].[CfgTipoMail] ([CfgTipoMailID]),
    CONSTRAINT [FK_PpalRepresentanteProveedorMail_PpalRepresentanteProveedor] FOREIGN KEY ([PpalRepresentanteProveedorID]) REFERENCES [dbo].[PpalRepresentanteProveedor] ([PpalRepresentanteProveedorID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalRepresentanteProveedorMail_PpalRepresentanteProveedorID_Mail]
    ON [dbo].[PpalRepresentanteProveedorMail]([PpalRepresentanteProveedorID] ASC, [Mail] ASC);

