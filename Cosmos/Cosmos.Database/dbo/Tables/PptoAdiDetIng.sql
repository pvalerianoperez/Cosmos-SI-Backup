CREATE TABLE [dbo].[PptoAdiDetIng] (
    [PptoAdiDetIngID] INT   IDENTITY (1, 1) NOT NULL,
    [PptoAdiEncIngID] INT   NOT NULL,
    [PptoPerIngID]    INT   NOT NULL,
    [Importe]         MONEY NULL,
    CONSTRAINT [PK_PptoAdiDetIng] PRIMARY KEY CLUSTERED ([PptoAdiDetIngID] ASC),
    CONSTRAINT [FK_PptoAdiDetIng_PptoAdiEncIng] FOREIGN KEY ([PptoAdiEncIngID]) REFERENCES [dbo].[PptoAdiEncIng] ([PptoAdiEncIngID]),
    CONSTRAINT [FK_PptoAdiDetIng_PptoPerIng] FOREIGN KEY ([PptoPerIngID]) REFERENCES [dbo].[PptoPerIng] ([PptoPerIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoAdiDetIng]
    ON [dbo].[PptoAdiDetIng]([PptoAdiEncIngID] ASC, [PptoPerIngID] ASC);

