CREATE TABLE [dbo].[PptoTrasDetIng] (
    [PptoTrasDetIngID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoTrasEncIngID] INT   NOT NULL,
    [PptoDetIngIDAdi]  INT   NOT NULL,
    [PptoDetIngIDDed]  INT   NOT NULL,
    [Importe]          MONEY NULL,
    CONSTRAINT [PK_PptoTrasDetIng] PRIMARY KEY CLUSTERED ([PptoTrasDetIngID] ASC),
    CONSTRAINT [FK_PptoTrasDetIng_PptoDetIng] FOREIGN KEY ([PptoDetIngIDAdi]) REFERENCES [dbo].[PptoDetIng] ([PptoDetIngID]),
    CONSTRAINT [FK_PptoTrasDetIng_PptoDetIng1] FOREIGN KEY ([PptoDetIngIDAdi]) REFERENCES [dbo].[PptoDetIng] ([PptoDetIngID]),
    CONSTRAINT [FK_PptoTrasDetIng_PptoDetIng2] FOREIGN KEY ([PptoDetIngIDDed]) REFERENCES [dbo].[PptoDetIng] ([PptoDetIngID]),
    CONSTRAINT [FK_PptoTrasDetIng_PptoTrasEncIng] FOREIGN KEY ([PptoTrasEncIngID]) REFERENCES [dbo].[PptoTrasEncIng] ([PptoTrasEncIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoTrasDetIng]
    ON [dbo].[PptoTrasDetIng]([PptoTrasEncIngID] ASC, [PptoDetIngIDAdi] ASC, [PptoDetIngIDDed] ASC);

