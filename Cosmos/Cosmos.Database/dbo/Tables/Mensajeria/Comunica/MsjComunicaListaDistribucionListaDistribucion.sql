CREATE TABLE [dbo].[MsjComunicaListaDistribucionListaDistribucion] (
    [MsjComunicaListaDistribucionListaDistribucionID] INT NOT NULL,
    [ListaDistribucionID]                             INT NOT NULL,
    [MiembroListaDistribucionID]                      INT NOT NULL,
    CONSTRAINT [PK_MsjComunicaListaDistribucionListaDistribucion] PRIMARY KEY CLUSTERED ([MsjComunicaListaDistribucionListaDistribucionID] ASC),
    CONSTRAINT [FK_MsjComunicaListaDistribucionListaDistribucion_MsjComunicaListaDistribucion] FOREIGN KEY ([ListaDistribucionID]) REFERENCES [dbo].[MsjComunicaListaDistribucion] ([ListaDistribucionID]),
    CONSTRAINT [FK_MsjComunicaListaDistribucionListaDistribucion_MsjComunicaListaDistribucion_1] FOREIGN KEY ([MiembroListaDistribucionID]) REFERENCES [dbo].[MsjComunicaListaDistribucion] ([ListaDistribucionID]),
    CONSTRAINT [AK_MsjComunicaListaDistribucionListaDistribucion_ListaDistribucionID] UNIQUE NONCLUSTERED ([ListaDistribucionID] ASC, [MiembroListaDistribucionID] ASC)
);



GO

CREATE INDEX [IX_MsjComunicaListaDistribucionListaDistribucion_ListaDistribucionID] ON [dbo].[MsjComunicaListaDistribucionListaDistribucion] ([ListaDistribucionID])
