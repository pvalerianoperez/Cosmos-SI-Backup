CREATE TABLE [dbo].[SistemaModulo] (
    [ModuloID]       INT            IDENTITY (1, 1) NOT NULL,
    [ModuloClave]    VARCHAR (4)    CONSTRAINT [DF_SistemaModulo_ModuloClave] DEFAULT ('"') NOT NULL,
    [Nombre]         NVARCHAR (50)  NOT NULL,
    [NombreCorto]    NVARCHAR (20)  NOT NULL,
    [RecursoWebSite] NVARCHAR (150) NOT NULL,
    [Icono]          NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_SistemaModulo] PRIMARY KEY CLUSTERED ([ModuloID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_SistemaModulo_ModuloClave]
    ON [dbo].[SistemaModulo]([ModuloClave] ASC);

