CREATE TABLE [dbo].[SistemaNivelProducto] (
    [NivelProductoID]    INT          IDENTITY (1, 1) NOT NULL,
    [NivelProductoClave] VARCHAR (4)  NOT NULL,
    [Nombre]             VARCHAR (25) NOT NULL,
    [NombreCorto]        VARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_NivelProducto] PRIMARY KEY CLUSTERED ([NivelProductoID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SistemaNivelProducto]
    ON [dbo].[SistemaNivelProducto]([NivelProductoClave] ASC);

