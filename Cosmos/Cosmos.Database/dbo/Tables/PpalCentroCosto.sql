CREATE TABLE [dbo].[PpalCentroCosto] (
    [PpalCentroCostoID]    INT          IDENTITY (1, 1) NOT NULL,
    [EmpresaID]            INT          NOT NULL,
    [PpalCentroCostoClave] VARCHAR (6)  NOT NULL,
    [Nombre]               VARCHAR (40) NOT NULL,
    [NombreCorto]          VARCHAR (10) NOT NULL,
    [Administracion]       CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PpalCentroCostoID] PRIMARY KEY CLUSTERED ([PpalCentroCostoID] ASC),
    CONSTRAINT [FK_PpalCentroCosto_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalCentroCosto_EmpresaID_PpalCentroCostoClave_]
    ON [dbo].[PpalCentroCosto]([EmpresaID] ASC, [PpalCentroCostoClave] ASC);

