CREATE TABLE [dbo].[PptoAdiEncEgr] (
    [PptoAdiEncEgrID]    INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncEgrID]       INT           NOT NULL,
    [FechaHora]          DATETIME      NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoAdiEncEgr] PRIMARY KEY CLUSTERED ([PptoAdiEncEgrID] ASC),
    CONSTRAINT [FK_PptoAdiEncEgr_PptoEncEgr] FOREIGN KEY ([PptoEncEgrID]) REFERENCES [dbo].[PptoEncEgr] ([PptoEncEgrID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoAdiEncEgr]
    ON [dbo].[PptoAdiEncEgr]([PptoEncEgrID] ASC, [FechaHora] ASC);

