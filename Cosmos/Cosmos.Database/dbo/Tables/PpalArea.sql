CREATE TABLE [dbo].[PpalArea] (
    [PpalAreaID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalAreaClave] VARCHAR (10) NOT NULL,
    [Nombre]        VARCHAR (60) NOT NULL,
    [NombreCorto]   VARCHAR (10) NOT NULL,
    [EmpresaID]     INT          NOT NULL,
    CONSTRAINT [PK_PpalAreaID] PRIMARY KEY CLUSTERED ([PpalAreaID] ASC),
    CONSTRAINT [FK_PpalArea_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalArea_EmpresaID_PpalAreaClave]
    ON [dbo].[PpalArea]([EmpresaID] ASC, [PpalAreaClave] ASC);

