CREATE TABLE [dbo].[PptoDedEncEgr] (
    [PptoDedEncEgrID]    INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncEgrID]       INT           NOT NULL,
    [FechaHora]          DATETIME      NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoDedEncEgr] PRIMARY KEY CLUSTERED ([PptoDedEncEgrID] ASC),
    CONSTRAINT [FK_PptoDedEncEgr_PptoEncEgr] FOREIGN KEY ([PptoEncEgrID]) REFERENCES [dbo].[PptoEncEgr] ([PptoEncEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoDedEncEgr]
    ON [dbo].[PptoDedEncEgr]([PptoEncEgrID] ASC, [FechaHora] ASC);

