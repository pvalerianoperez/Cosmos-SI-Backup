CREATE TABLE [dbo].[SistemaTipoFecha] (
    [TipoFechaID]    INT          IDENTITY (1, 1) NOT NULL,
    [TipoFechaClave] VARCHAR (10) NOT NULL,
    [Nombre]         VARCHAR (30) NOT NULL,
    [NombreCorto]    VARCHAR (10) NOT NULL,
    [Estatus]        BIT          NOT NULL,
    CONSTRAINT [PK_SistemaTipoFecha] PRIMARY KEY CLUSTERED ([TipoFechaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoFecha_SistemaTipoFechaClave]
    ON [dbo].[SistemaTipoFecha]([TipoFechaClave] ASC);

