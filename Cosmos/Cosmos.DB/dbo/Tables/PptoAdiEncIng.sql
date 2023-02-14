CREATE TABLE [dbo].[PptoAdiEncIng] (
    [PptoAdiEncIngID]    INT           IDENTITY (1, 1) NOT NULL,
    [PptoEncIngID]       INT           NOT NULL,
    [EstatusDocumentoID] VARCHAR (10)  NOT NULL,
    [FechaHora]          DATETIME      NULL,
    [Comentarios]        VARCHAR (200) NULL,
    CONSTRAINT [PK_PptoAdiEncIng] PRIMARY KEY CLUSTERED ([PptoAdiEncIngID] ASC),
    CONSTRAINT [FK_PptoAdiEncIng_PptoEncIng] FOREIGN KEY ([PptoEncIngID]) REFERENCES [dbo].[PptoEncIng] ([PptoEncIngID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PptoAdiEncIng]
    ON [dbo].[PptoAdiEncIng]([PptoEncIngID] ASC, [FechaHora] ASC);

