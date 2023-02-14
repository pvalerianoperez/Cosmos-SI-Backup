CREATE TABLE [dbo].[PptoConcepto] (
    [PptoConceptoID] INT           IDENTITY (1, 1) NOT NULL,
    [Concepto]       VARCHAR (500) NOT NULL,
    [EmpresaID]      INT           NOT NULL,
    CONSTRAINT [PK_PptoConcepto] PRIMARY KEY CLUSTERED ([PptoConceptoID] ASC),
    CONSTRAINT [FK_PptoConcepto_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoConcepto_EmpresaID_Concepto]
    ON [dbo].[PptoConcepto]([EmpresaID] ASC, [Concepto] ASC);

