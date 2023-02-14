CREATE TABLE [dbo].[SATRegimenFiscal] (
    [SATRegimenFiscalID]    INT           IDENTITY (1, 1) NOT NULL,
    [SATRegimenFiscalClave] VARCHAR (10)  NOT NULL,
    [Nombre]                VARCHAR (110) NOT NULL,
    [NombreCorto]           VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_SATRegimenFiscal] PRIMARY KEY CLUSTERED ([SATRegimenFiscalID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SATRegimenFiscal]
    ON [dbo].[SATRegimenFiscal]([SATRegimenFiscalClave] ASC);

