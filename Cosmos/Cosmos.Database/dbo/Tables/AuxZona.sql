CREATE TABLE [dbo].[AuxZona] (
    [AuxZonaID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxZonaClave] VARCHAR (5)  NULL,
    [Nombre]       VARCHAR (50) NULL,
    [NombreCorto]  VARCHAR (20) NULL,
    CONSTRAINT [PK_AuxZona] PRIMARY KEY CLUSTERED ([AuxZonaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Zona]
    ON [dbo].[AuxZona]([AuxZonaClave] ASC);

