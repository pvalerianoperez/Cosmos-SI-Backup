CREATE TABLE [dbo].[CoModelo] (
    [CoModeloID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoModeloClave] VARCHAR (10) NOT NULL,
    [Nombre]        VARCHAR (60) NOT NULL,
    [NombreCorto]   VARCHAR (10) NOT NULL,
    [EmpresaID]     INT          NOT NULL,
    CONSTRAINT [PK_CoModelo] PRIMARY KEY CLUSTERED ([CoModeloID] ASC),
    CONSTRAINT [FK_CoModelo_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoModelo_EmpresaID_CoModeloClave]
    ON [dbo].[CoModelo]([EmpresaID] ASC, [CoModeloClave] ASC);

