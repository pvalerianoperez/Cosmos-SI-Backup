CREATE TABLE [dbo].[EspCiudad] (
    [EspCiudadID]    INT          IDENTITY (1, 1) NOT NULL,
    [EspCiudadClave] VARCHAR (7)  NOT NULL,
    [Nombre]         VARCHAR (60) NOT NULL,
    [NombreCorto]    VARCHAR (15) NOT NULL,
    [EspMunicipioID] INT          NOT NULL,
    CONSTRAINT [PK_EspCiudad] PRIMARY KEY CLUSTERED ([EspCiudadID] ASC),
    CONSTRAINT [FK_Ciudad_EspMunicipio] FOREIGN KEY ([EspMunicipioID]) REFERENCES [dbo].[EspMunicipio] ([EspMunicipioID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ciudad_CiudadClave]
    ON [dbo].[EspCiudad]([EspCiudadClave] ASC);

