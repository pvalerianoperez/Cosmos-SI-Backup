CREATE TABLE [dbo].[CfgTipoFecha] (
    [CfgTipoFechaID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoFechaClave] VARCHAR (10) NOT NULL,
    [Nombre]            VARCHAR (40) NOT NULL,
    [NombreCorto]       VARCHAR (15) NOT NULL,
    [Estatus]           BIT          NOT NULL,
    [TipoFechaID]       INT          NOT NULL,
    CONSTRAINT [PK_CfgTipoFecha] PRIMARY KEY CLUSTERED ([CfgTipoFechaID] ASC),
    CONSTRAINT [FK_CfgTipoFecha_SistemaTipoFecha] FOREIGN KEY ([TipoFechaID]) REFERENCES [dbo].[SistemaTipoFecha] ([TipoFechaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoFecha_TipoFechaClave]
    ON [dbo].[CfgTipoFecha]([CfgTipoFechaClave] ASC);

