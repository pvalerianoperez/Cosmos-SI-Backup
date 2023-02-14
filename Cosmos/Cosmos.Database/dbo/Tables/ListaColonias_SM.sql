CREATE TABLE [dbo].[ListaColonias_SM] (
    [ID_Asentamiento]     NCHAR (10)    NOT NULL,
    [Nombre_Asentamiento] VARCHAR (MAX) NULL,
    [CP_Asentamiento]     INT           NULL,
    [Tipo_Asentamiento]   INT           NULL,
    [ID_Ciudad]           VARCHAR (50)  NOT NULL,
    [ID_Municipio]        VARCHAR (50)  NULL,
    [ID_Estado]           INT           NULL,
    CONSTRAINT [PK_ListaColonias_SM] PRIMARY KEY CLUSTERED ([ID_Asentamiento] ASC, [ID_Ciudad] ASC)
);

