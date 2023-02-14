CREATE TABLE [dbo].[ListaTodosEstados_SM] (
    [Codigo_CP]       NCHAR (6)    NOT NULL,
    [Nombre_Asenta]   VARCHAR (70) NULL,
    [Tipo_Asenta]     VARCHAR (30) NULL,
    [Nombre_Mun]      VARCHAR (55) NULL,
    [Nombre_Estado]   VARCHAR (60) NULL,
    [Nombre_Ciudad]   VARCHAR (80) NULL,
    [D_CP]            NCHAR (6)    NULL,
    [Codigo_Estado]   NCHAR (3)    NULL,
    [C_Oficina]       NCHAR (6)    NULL,
    [c_CP]            NCHAR (6)    NULL,
    [Codigo_TipoAsen] NCHAR (4)    NULL,
    [Codigo_Mun]      NCHAR (5)    NULL,
    [Id_Asen_Pcons]   NCHAR (6)    NOT NULL,
    [Nombre_Zona]     VARCHAR (15) NULL,
    [Clave_Ciudad]    NCHAR (10)   NULL,
    [Municipio_id]    VARCHAR (10) NULL,
    [ciudad_id]       VARCHAR (10) NULL,
    CONSTRAINT [PK_ListaTodosEstados_SM] PRIMARY KEY CLUSTERED ([Codigo_CP] ASC, [Id_Asen_Pcons] ASC)
);

