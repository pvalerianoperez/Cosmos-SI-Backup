CREATE TABLE [dbo].[PptoTrasEncIng] (
    [PptoTrasEncIngID]   INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncIngID]       INT           NOT NULL,
    [FechaHora]          DATETIME      NOT NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoTrasEncIng] PRIMARY KEY CLUSTERED ([PptoTrasEncIngID] ASC),
    CONSTRAINT [FK_PptoTrasEncIng_PptoEncIng] FOREIGN KEY ([PptoEncIngID]) REFERENCES [dbo].[PptoEncIng] ([PptoEncIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoTrasEncIng]
    ON [dbo].[PptoTrasEncIng]([PptoEncIngID] ASC, [FechaHora] ASC);

