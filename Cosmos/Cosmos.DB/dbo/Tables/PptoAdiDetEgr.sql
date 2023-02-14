CREATE TABLE [dbo].[PptoAdiDetEgr] (
    [PptoAdiDetEgrID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoAdiEncEgrID] INT   NOT NULL,
    [PptoPerEgrID]    INT   NOT NULL,
    [Importe]         MONEY NULL,
    CONSTRAINT [PK_PptoAdiDetEgr] PRIMARY KEY CLUSTERED ([PptoAdiDetEgrID] ASC),
    CONSTRAINT [FK_PptoAdiDetEgr_PptoAdiEncEgr] FOREIGN KEY ([PptoAdiEncEgrID]) REFERENCES [dbo].[PptoAdiEncEgr] ([PptoAdiEncEgrID]),
    CONSTRAINT [FK_PptoAdiDetEgr_PptoPerEgr] FOREIGN KEY ([PptoPerEgrID]) REFERENCES [dbo].[PptoPerEgr] ([PptoPerEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoAdiDetEgr]
    ON [dbo].[PptoAdiDetEgr]([PptoAdiEncEgrID] ASC, [PptoPerEgrID] ASC);

