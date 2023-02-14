CREATE TABLE [dbo].[SistemaCS] (
    [Tabla]      NVARCHAR (50) NOT NULL,
    [NS]         NVARCHAR (50) NULL,
    [ModuloID]   INT           NULL,
    [gEntidad]   BIT           NULL,
    [gASPX]      BIT           NULL,
    [gAPI]       BIT           NULL,
    [gAPIClient] BIT           NULL,
    [gSQL]       BIT           NULL,
    [gNegocio]   BIT           NULL,
    [dSQL]       BIT           NULL,
    CONSTRAINT [PK_SistemaCS] PRIMARY KEY CLUSTERED ([Tabla] ASC),
    CONSTRAINT [FK_SistemaCS_SistemaCSConfig] FOREIGN KEY ([NS]) REFERENCES [dbo].[SistemaCSConfig] ([NS]),
    CONSTRAINT [FK_SistemaCS_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID]),
    CONSTRAINT [FK_SistemaCS_SistemaModulo1] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID])
);



