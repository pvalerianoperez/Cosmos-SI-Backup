CREATE TABLE [dbo].[RHCuotaPatronal] (
    [RHCuotaPatronalId]    INT          NOT NULL,
    [EmpresaID]            INT          NOT NULL,
    [RHCuotaPatronalClave] VARCHAR (6)  NOT NULL,
    [Nombre]               VARCHAR (60) NOT NULL,
    [NombreCorto]          VARCHAR (10) NOT NULL,
    [ConceptoEgresoID]     INT          NOT NULL,
    [FechaInicial]         DATE         NOT NULL,
    [FechaFinal]           DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([RHCuotaPatronalId] ASC),
    CONSTRAINT [FK_RHCuotaPatronal_ConceptoEgreso] FOREIGN KEY ([ConceptoEgresoID]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]) ON UPDATE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_RHCuotaPatronal]
    ON [dbo].[RHCuotaPatronal]([EmpresaID] ASC, [RHCuotaPatronalClave] ASC);

