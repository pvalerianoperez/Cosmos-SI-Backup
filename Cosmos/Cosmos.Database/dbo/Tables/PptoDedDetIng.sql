CREATE TABLE [dbo].[PptoDedDetIng] (
    [PptoDedDetIngID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoDedEncIngID] INT   NOT NULL,
    [PptoDetIngID]    INT   NOT NULL,
    [Importe]         MONEY NULL,
    CONSTRAINT [PK_PptoDedDetIng] PRIMARY KEY CLUSTERED ([PptoDedDetIngID] ASC),
    CONSTRAINT [FK_PptoDedDetIng_PptoDedEncIng] FOREIGN KEY ([PptoDedEncIngID]) REFERENCES [dbo].[PptoDedEncIng] ([PptoDedEncIngID]),
    CONSTRAINT [FK_PptoDedDetIng_PptoDetIng] FOREIGN KEY ([PptoDetIngID]) REFERENCES [dbo].[PptoDetIng] ([PptoDetIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDedDetIng]
    ON [dbo].[PptoDedDetIng]([PptoDedEncIngID] ASC, [PptoDetIngID] ASC);

