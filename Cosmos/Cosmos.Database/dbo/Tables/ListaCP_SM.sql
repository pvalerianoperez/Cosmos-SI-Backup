CREATE TABLE [dbo].[ListaCP_SM] (
    [Codigo_CP] NCHAR (7)  NOT NULL,
    [ID_Ciudad] NCHAR (11) NULL,
    [CiudadID]  INT        NULL,
    CONSTRAINT [PK_ListaCP_SM] PRIMARY KEY CLUSTERED ([Codigo_CP] ASC)
);

