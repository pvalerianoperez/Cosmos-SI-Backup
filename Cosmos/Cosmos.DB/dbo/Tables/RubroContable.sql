CREATE TABLE [dbo].[RubroContable] (
    [RubroContableID]      INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]               VARCHAR (60) NOT NULL,
    [NombreCorto]          VARCHAR (10) NOT NULL,
    [PpalCuentaContableID] INT          NULL,
    [TituloRubroID]        INT          NOT NULL,
    CONSTRAINT [PK_RubroContable] PRIMARY KEY CLUSTERED ([RubroContableID] ASC),
    CONSTRAINT [FK_RubroContable_CuentaContable] FOREIGN KEY ([PpalCuentaContableID]) REFERENCES [dbo].[PpalCuentaContable] ([PpalCuentaContableID]),
    CONSTRAINT [FK_RubroContable_TìtuloRubro] FOREIGN KEY ([TituloRubroID]) REFERENCES [dbo].[TituloRubro] ([TituloRubroID])
);

