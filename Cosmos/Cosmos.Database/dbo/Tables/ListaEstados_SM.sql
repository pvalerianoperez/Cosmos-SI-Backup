CREATE TABLE [dbo].[ListaEstados_SM] (
    [ID_Estado]       INT          NOT NULL,
    [Nombre_Estado]   VARCHAR (50) NULL,
    [Nombre_Corto2]   VARCHAR (3)  NULL,
    [Nombre_Corto3]   VARCHAR (4)  NULL,
    [Nombre_Renapo]   VARCHAR (2)  NULL,
    [Nombre_Variable] VARCHAR (15) NULL,
    CONSTRAINT [PK_ListaEstados_SM] PRIMARY KEY CLUSTERED ([ID_Estado] ASC)
);

