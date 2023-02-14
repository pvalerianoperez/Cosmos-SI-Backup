CREATE TABLE [dbo].[PptoDesgIng] (
    [PptoDesgIngID]     INT   IDENTITY (1, 1) NOT NULL,
    [PptoPerIngID]      INT   NULL,
    [PptoConceptoID]    INT   NOT NULL,
    [ImporteSolicitado] MONEY NULL,
    CONSTRAINT [PK_PptoDesgIng] PRIMARY KEY CLUSTERED ([PptoDesgIngID] ASC),
    CONSTRAINT [FK_PptoDesgIng_PptoConcepto] FOREIGN KEY ([PptoConceptoID]) REFERENCES [dbo].[PptoConcepto] ([PptoConceptoID]),
    CONSTRAINT [FK_PptoDesgIng_PptoPerIng] FOREIGN KEY ([PptoPerIngID]) REFERENCES [dbo].[PptoPerIng] ([PptoPerIngID]) ON DELETE CASCADE
);

