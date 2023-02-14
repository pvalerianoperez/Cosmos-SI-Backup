CREATE TABLE [dbo].[ListaPaises_SM$] (
    [Nombre común]                             NVARCHAR (255) NOT NULL,
    [Nombre ISO oficial del país o territorio] NVARCHAR (255) NULL,
    [Código alfa-2]                            NVARCHAR (255) NULL,
    [Código alfa-3]                            NVARCHAR (255) NOT NULL,
    [Código numérico]                          FLOAT (53)     NULL,
    [Codigo_LADA]                              VARCHAR (15)   NULL,
    CONSTRAINT [PK_ListaPaises_SM$] PRIMARY KEY CLUSTERED ([Nombre común] ASC, [Código alfa-3] ASC)
);

