CREATE TABLE [dbo].[ListaCiudades_SM] (
    [ID_Ciudad]     VARCHAR (10) NOT NULL,
    [Nombre_Ciudad] VARCHAR (70) NULL,
    [ID_Municipio]  VARCHAR (10) NULL,
    [ID_Estado]     INT          NULL,
    [Codigo_CP]     NCHAR (6)    NULL,
    [MunicipioID]   INT          NULL,
    CONSTRAINT [PK_ListaCiudades_SM] PRIMARY KEY CLUSTERED ([ID_Ciudad] ASC)
);

