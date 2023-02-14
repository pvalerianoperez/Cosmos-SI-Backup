CREATE TABLE [dbo].[PpalConceptoEgreso] (
    [PpalConceptoEgresoID]    INT          IDENTITY (1, 1) NOT NULL,
    [PpalConceptoEgresoClave] VARCHAR (10) NOT NULL,
    [Nombre]                  VARCHAR (60) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    [CompraFactura]           CHAR (1)     NOT NULL,
    [Desglosar]               CHAR (1)     NOT NULL,
    [EmpresaID]               INT          NULL,
    CONSTRAINT [PK_PpalConceptoEgreso] PRIMARY KEY CLUSTERED ([PpalConceptoEgresoID] ASC),
    CONSTRAINT [FK_ConceptoEgreso_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ConceptoEgreso]
    ON [dbo].[PpalConceptoEgreso]([EmpresaID] ASC, [PpalConceptoEgresoClave] ASC);

