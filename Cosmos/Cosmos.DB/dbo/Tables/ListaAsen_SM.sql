CREATE TABLE [dbo].[ListaAsen_SM] (
    [Tipo_Asentamiento]   INT          NOT NULL,
    [Nombre_Asentamiento] VARCHAR (50) NULL,
    CONSTRAINT [PK_ListaAsen_SM] PRIMARY KEY CLUSTERED ([Tipo_Asentamiento] ASC)
);

