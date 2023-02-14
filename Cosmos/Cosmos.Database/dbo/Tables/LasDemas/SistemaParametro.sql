CREATE TABLE [dbo].[SistemaParametro] (
    [SistemaParametroID] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]             VARCHAR (50) NOT NULL,
    [ModuloID]           INT          NOT NULL,
    [Valor]              VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_SistemaParametro] PRIMARY KEY CLUSTERED ([SistemaParametroID] ASC),
    CONSTRAINT [FK_SistemaParametro_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID])
);



