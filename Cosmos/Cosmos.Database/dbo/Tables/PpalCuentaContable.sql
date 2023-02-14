CREATE TABLE [dbo].[PpalCuentaContable] (
    [PpalCuentaContableID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalCuentaContableClave] VARCHAR (20) NOT NULL,
    [Nombre]                  VARCHAR (60) NOT NULL,
    [PadreID]                 INT          NULL,
    [EmpresaID]               INT          NOT NULL,
    CONSTRAINT [PK_PpalCuentaContable] PRIMARY KEY CLUSTERED ([PpalCuentaContableID] ASC),
    CONSTRAINT [FK_CuentaContable_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalCuentaContable_PpalCuentaContableClave]
    ON [dbo].[PpalCuentaContable]([PpalCuentaContableClave] ASC);

