CREATE TABLE [dbo].[PptoDedEncIng] (
    [PptoDedEncIngID]    INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncIngID]       INT           NOT NULL,
    [FechaHora]          DATETIME      NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoDedEncIng] PRIMARY KEY CLUSTERED ([PptoDedEncIngID] ASC),
    CONSTRAINT [FK_PptoDedEncIng_PptoEncIng] FOREIGN KEY ([PptoEncIngID]) REFERENCES [dbo].[PptoEncIng] ([PptoEncIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDedEncIng]
    ON [dbo].[PptoDedEncIng]([PptoEncIngID] ASC, [FechaHora] ASC);

