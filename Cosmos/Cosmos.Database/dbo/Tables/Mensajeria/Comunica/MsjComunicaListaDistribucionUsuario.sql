CREATE TABLE [dbo].[MsjComunicaListaDistribucionUsuario] (
    [MsjComunicaListaDistribucionUsuario] INT NOT NULL,
    [ListaDistribucionID]                 INT NOT NULL,
    [UsuarioID]                           INT NOT NULL,
    CONSTRAINT [PK_MsjComunicaListaDistribucionUsuario] PRIMARY KEY CLUSTERED ([MsjComunicaListaDistribucionUsuario] ASC),
    CONSTRAINT [FK_MsjComunicaListaDistribucionUser_ListaDistribucionID] FOREIGN KEY ([ListaDistribucionID]) REFERENCES [dbo].[MsjComunicaListaDistribucion] ([ListaDistribucionID]),
    CONSTRAINT [FK_MsjComunicaListaDistribucionUser_SegUsuario_1] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]),
    CONSTRAINT [AK_MsjComunicaListaDistribucionUser_ListaDistribucionID_UsuarioID] UNIQUE NONCLUSTERED ([ListaDistribucionID] ASC, [UsuarioID] ASC)
);



GO

CREATE INDEX [IX_MsjComunicaListaDistribucionUsuario_ListaDistribucionID] ON [dbo].[MsjComunicaListaDistribucionUsuario] ([ListaDistribucionID])
