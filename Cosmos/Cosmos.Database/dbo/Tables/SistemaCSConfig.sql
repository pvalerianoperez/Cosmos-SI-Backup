CREATE TABLE [dbo].[SistemaCSConfig] (
    [NS]            NVARCHAR (50)  NOT NULL,
    [EntidadesDir]  NVARCHAR (150) NULL,
    [APIDir]        NVARCHAR (150) NULL,
    [APIClienteDir] NVARCHAR (150) NULL,
    [SQLDir]        NVARCHAR (150) NULL,
    [ASPXDir]       NVARCHAR (150) NULL,
    [SitemapDir]    NVARCHAR (150) NULL,
    [NegocioDir]    NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([NS] ASC)
);

