CREATE TABLE [dbo].[EspEstado] (
    [EspEstadoID]    INT          IDENTITY (1, 1) NOT NULL,
    [EspEstadoClave] VARCHAR (6)  NOT NULL,
    [ClaveCURP]      VARCHAR (3)  NOT NULL,
    [Clave2]         VARCHAR (2)  NOT NULL,
    [Clave3]         VARCHAR (3)  NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [NombreCorto]    VARCHAR (15) NOT NULL,
    [NombreCompleto] VARCHAR (50) NOT NULL,
    [EspPaisID]      INT          NOT NULL,
    CONSTRAINT [PK_EspEstado] PRIMARY KEY CLUSTERED ([EspEstadoID] ASC),
    CONSTRAINT [FK_EspEstado_EspPais] FOREIGN KEY ([EspPaisID]) REFERENCES [dbo].[EspPais] ([EspPaisID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Estado]
    ON [dbo].[EspEstado]([EspEstadoClave] ASC);

