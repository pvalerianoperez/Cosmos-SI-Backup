CREATE TABLE [dbo].[PptoTrasDetEgr] (
    [PptoTrasDetEgrID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoTrasEncEgrID] INT   NOT NULL,
    [PptoDetEgrIDAdi]  INT   NOT NULL,
    [PptoDetEgrIDDed]  INT   NOT NULL,
    [Importe]          MONEY NULL,
    CONSTRAINT [PK_PptoTrasDetEgr] PRIMARY KEY CLUSTERED ([PptoTrasDetEgrID] ASC),
    CONSTRAINT [FK_PptoTrasDetEgr_PptoDetEgr] FOREIGN KEY ([PptoDetEgrIDAdi]) REFERENCES [dbo].[PptoDetEgr] ([PptoDetEgrID]),
    CONSTRAINT [FK_PptoTrasDetEgr_PptoDetEgr1] FOREIGN KEY ([PptoDetEgrIDDed]) REFERENCES [dbo].[PptoDetEgr] ([PptoDetEgrID]),
    CONSTRAINT [FK_PptoTrasDetEgr_PptoTrasEncEgr] FOREIGN KEY ([PptoTrasEncEgrID]) REFERENCES [dbo].[PptoTrasEncEgr] ([PptoTrasEncEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoTrasDetEgr]
    ON [dbo].[PptoTrasDetEgr]([PptoTrasEncEgrID] ASC, [PptoDetEgrIDAdi] ASC, [PptoDetEgrIDDed] ASC);

