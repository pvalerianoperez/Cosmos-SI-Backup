CREATE TABLE [dbo].[ListaPaises] (
    [ID_Pais]     INT           NOT NULL,
    [Nombre_Pais] VARCHAR (MAX) NULL,
    [Codigo_Pais] VARCHAR (50)  NULL,
    CONSTRAINT [PK_ListaPaises] PRIMARY KEY CLUSTERED ([ID_Pais] ASC)
);

