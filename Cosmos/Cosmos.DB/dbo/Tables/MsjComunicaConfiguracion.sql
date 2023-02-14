CREATE TABLE [dbo].[MsjComunicaConfiguracion] (
    [Llave]       NVARCHAR (100) NOT NULL,
    [Valor]       NVARCHAR (MAX) NOT NULL,
    [Descripcion] VARCHAR (250)  NULL,
    PRIMARY KEY CLUSTERED ([Llave] ASC)
);

