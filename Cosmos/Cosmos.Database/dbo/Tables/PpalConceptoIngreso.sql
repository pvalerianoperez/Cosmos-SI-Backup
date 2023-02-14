CREATE TABLE [dbo].[PpalConceptoIngreso] (
    [PpalConceptoIngresoID]    INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]                   VARCHAR (60) NOT NULL,
    [NombreCorto]              VARCHAR (10) NOT NULL,
    [SistemaEmpresaID]         INT          NOT NULL,
    [PpalConceptoIngresoClave] VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_PpalConceptoIngreso] PRIMARY KEY CLUSTERED ([PpalConceptoIngresoID] ASC),
    CONSTRAINT [FK_ConceptoIngreso_SistemaEmpresa] FOREIGN KEY ([SistemaEmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ConceptoIngreso_Column]
    ON [dbo].[PpalConceptoIngreso]([SistemaEmpresaID] ASC, [PpalConceptoIngresoClave] ASC);

