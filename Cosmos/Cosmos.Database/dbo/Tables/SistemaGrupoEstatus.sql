CREATE TABLE [dbo].[SistemaGrupoEstatus] (
    [SistemaGrupoEstatusID] INT          IDENTITY (1, 1) NOT NULL,
    [SistemaGrupoID]        INT          NOT NULL,
    [Nombre]                VARCHAR (50) NOT NULL,
    [TipoDocumentoID]       INT          NOT NULL,
    [Color]                 VARCHAR (30) NOT NULL,
    [Activo]                BIT          NOT NULL,
    CONSTRAINT [PK_SistemaGrupoEstatus] PRIMARY KEY CLUSTERED ([SistemaGrupoEstatusID] ASC),
    CONSTRAINT [FK_SistemaGrupoEstatus_SistemaGrupo] FOREIGN KEY ([SistemaGrupoID]) REFERENCES [dbo].[SistemaGrupo] ([SistemaGrupoID]),
    CONSTRAINT [FK_SistemaGrupoEstatus_SistemaTipoDocumento] FOREIGN KEY ([TipoDocumentoID]) REFERENCES [dbo].[SistemaTipoDocumento] ([TipoDocumentoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaGrupo_SistemaGrupoID_TipoDocumentoID_Nombre]
    ON [dbo].[SistemaGrupoEstatus]([SistemaGrupoID] ASC, [TipoDocumentoID] ASC, [Nombre] ASC);

