CREATE TABLE [dbo].[EspColonia] (
    [EspColoniaID]          INT          IDENTITY (1, 1) NOT NULL,
    [EspColoniaClave]       VARCHAR (7)  NOT NULL,
    [Nombre]                VARCHAR (60) NOT NULL,
    [NombreCorto]           VARCHAR (15) NOT NULL,
    [CfgTipoAsentamientoID] INT          NOT NULL,
    [EspCiudadID]           INT          NOT NULL,
    [EspCP]                 INT          NOT NULL,
    CONSTRAINT [PK_EspColonia] PRIMARY KEY CLUSTERED ([EspColoniaID] ASC),
    CONSTRAINT [FK__EspColonia__CfgTipoAsentamiento] FOREIGN KEY ([CfgTipoAsentamientoID]) REFERENCES [dbo].[CfgTipoAsentamiento] ([CfgTipoAsentamientoID]),
    CONSTRAINT [FK__EspColonia__EspCiudad] FOREIGN KEY ([EspCiudadID]) REFERENCES [dbo].[EspCiudad] ([EspCiudadID]),
    CONSTRAINT [FK__EspColonia__EspCP] FOREIGN KEY ([EspCP]) REFERENCES [dbo].[EspCP] ([EspCP])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EspColonia]
    ON [dbo].[EspColonia]([EspCiudadID] ASC, [EspColoniaClave] ASC);

