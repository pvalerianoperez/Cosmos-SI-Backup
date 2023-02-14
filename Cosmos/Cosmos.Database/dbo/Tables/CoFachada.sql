CREATE TABLE [dbo].[CoFachada] (
    [CoFachadaID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoFachadaClave] VARCHAR (10) NOT NULL,
    [Nombre]         VARCHAR (60) NOT NULL,
    [NombreCorto]    VARCHAR (10) NOT NULL,
    [EmpresaID]      INT          NOT NULL,
    CONSTRAINT [PK_CoFachada] PRIMARY KEY CLUSTERED ([CoFachadaID] ASC),
    CONSTRAINT [FK_CoFachada_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoFachada_EmpresaID_CoFachadaClave]
    ON [dbo].[CoFachada]([EmpresaID] ASC, [CoFachadaClave] ASC);

