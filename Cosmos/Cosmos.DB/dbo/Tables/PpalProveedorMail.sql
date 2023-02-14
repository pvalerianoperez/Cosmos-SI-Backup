CREATE TABLE [dbo].[PpalProveedorMail] (
    [PpalProveedorMailID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalProveedorID]     INT           NOT NULL,
    [CfgTipoMailID]       INT           NOT NULL,
    [Mail]                VARCHAR (100) NOT NULL,
    [Predeterminado]      BIT           NOT NULL,
    [Comentarios]         VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PpalProveedorMail] PRIMARY KEY CLUSTERED ([PpalProveedorMailID] ASC),
    CONSTRAINT [FK_PpalProveedorMail_CfgTipoMail] FOREIGN KEY ([CfgTipoMailID]) REFERENCES [dbo].[CfgTipoMail] ([CfgTipoMailID]),
    CONSTRAINT [FK_PpalProveedorMail_PpalProveedor] FOREIGN KEY ([PpalProveedorID]) REFERENCES [dbo].[PpalProveedor] ([PpalProveedorID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalProveedorMail_PpalProveedorID_Mail]
    ON [dbo].[PpalProveedorMail]([PpalProveedorID] ASC, [Mail] ASC);

