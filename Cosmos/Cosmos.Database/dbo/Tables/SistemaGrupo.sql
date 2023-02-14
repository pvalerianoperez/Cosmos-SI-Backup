CREATE TABLE [dbo].[SistemaGrupo] (
    [SistemaGrupoID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [ModuloID]       INT          NOT NULL,
    [Activo]         BIT          NOT NULL,
    CONSTRAINT [PK_SistemaGrupo] PRIMARY KEY CLUSTERED ([SistemaGrupoID] ASC),
    CONSTRAINT [FK_SistemaGrupo_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID])
);

