CREATE TABLE [dbo].[PptoDedDetEgr] (
    [PptoDedDetEgrID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoDedEncEgrID] INT   NOT NULL,
    [PptoDetEgrID]    INT   NOT NULL,
    [Importe]         MONEY NULL,
    CONSTRAINT [PK_PptoDedDetEgr] PRIMARY KEY CLUSTERED ([PptoDedDetEgrID] ASC),
    CONSTRAINT [FK_PptoDedDetEgr_PptoDedEncEgr] FOREIGN KEY ([PptoDedEncEgrID]) REFERENCES [dbo].[PptoDedEncEgr] ([PptoDedEncEgrID]),
    CONSTRAINT [FK_PptoDedDetEgr_PptoDetEgr] FOREIGN KEY ([PptoDetEgrID]) REFERENCES [dbo].[PptoDetEgr] ([PptoDetEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDedDetEgr]
    ON [dbo].[PptoDedDetEgr]([PptoDedEncEgrID] ASC, [PptoDetEgrID] ASC);

