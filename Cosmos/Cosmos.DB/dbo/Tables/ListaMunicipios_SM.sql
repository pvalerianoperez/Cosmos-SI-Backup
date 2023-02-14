CREATE TABLE [dbo].[ListaMunicipios_SM] (
    [ID_Municipio]     VARCHAR (50) NOT NULL,
    [Nombre_Municipio] VARCHAR (50) NULL,
    [ID_Estado]        INT          NULL,
    CONSTRAINT [PK_ListaMunicipios_SM] PRIMARY KEY CLUSTERED ([ID_Municipio] ASC)
);

