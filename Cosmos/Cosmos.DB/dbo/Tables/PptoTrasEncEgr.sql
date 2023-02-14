CREATE TABLE [dbo].[PptoTrasEncEgr] (
    [PptoTrasEncEgrID]   INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncEgrID]       INT           NOT NULL,
    [FechaHora]          DATETIME      NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoTrasEncEgr] PRIMARY KEY CLUSTERED ([PptoTrasEncEgrID] ASC),
    CONSTRAINT [FK_PptoTrasEncEgr_PptoEncEgr] FOREIGN KEY ([PptoEncEgrID]) REFERENCES [dbo].[PptoEncEgr] ([PptoEncEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoTrasEncEgr]
    ON [dbo].[PptoTrasEncEgr]([PptoEncEgrID] ASC, [FechaHora] ASC);

