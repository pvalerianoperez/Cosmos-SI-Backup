CREATE TABLE [dbo].[PptoDesgEgr] (
    [PptoDesgEgrID]     INT   IDENTITY (1, 1) NOT NULL,
    [PptoPerEgrID]      INT   NULL,
    [PptoConceptoID]    INT   NOT NULL,
    [ImporteSolicitado] MONEY NULL,
    CONSTRAINT [PK_PptoDesgEgr] PRIMARY KEY CLUSTERED ([PptoDesgEgrID] ASC),
    CONSTRAINT [FK_PptoDesgEgr_PptoConcepto] FOREIGN KEY ([PptoConceptoID]) REFERENCES [dbo].[PptoConcepto] ([PptoConceptoID]),
    CONSTRAINT [FK_PptoDesgEgr_PptoPerEgr] FOREIGN KEY ([PptoPerEgrID]) REFERENCES [dbo].[PptoPerEgr] ([PptoPerEgrID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDesgEgr]
    ON [dbo].[PptoDesgEgr]([PptoPerEgrID] ASC, [PptoConceptoID] ASC);

