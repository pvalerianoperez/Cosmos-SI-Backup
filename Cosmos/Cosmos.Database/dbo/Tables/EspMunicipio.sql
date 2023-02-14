CREATE TABLE [dbo].[EspMunicipio] (
    [EspMunicipioID]    INT          IDENTITY (1, 1) NOT NULL,
    [EspMunicipioClave] VARCHAR (6)  NOT NULL,
    [Nombre]            VARCHAR (50) NOT NULL,
    [NombreCorto]       VARCHAR (15) NOT NULL,
    [EspEstadoID]       INT          NOT NULL,
    CONSTRAINT [PK_EspMunicipio] PRIMARY KEY CLUSTERED ([EspMunicipioID] ASC),
    CONSTRAINT [FK_EspMunicipio_EspEstado] FOREIGN KEY ([EspEstadoID]) REFERENCES [dbo].[EspEstado] ([EspEstadoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Municipio_MunicipioClave]
    ON [dbo].[EspMunicipio]([EspMunicipioClave] ASC);

