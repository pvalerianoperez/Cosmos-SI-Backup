CREATE TABLE [dbo].[SistemaClaseProducto] (
    [ClaseProductoID]    INT          IDENTITY (1, 1) NOT NULL,
    [ClaseProductoClave] VARCHAR (4)  NOT NULL,
    [Nombre]             VARCHAR (25) NOT NULL,
    [NombreCorto]        VARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_ClaseProducto] PRIMARY KEY CLUSTERED ([ClaseProductoID] ASC)
);

