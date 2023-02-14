CREATE TABLE [dbo].[SistemaEstatusProducto] (
    [EstatusProductoID]    INT          IDENTITY (1, 1) NOT NULL,
    [EstatusProductoClave] VARCHAR (4)  NOT NULL,
    [Nombre]               VARCHAR (25) NOT NULL,
    [NombreCorto]          VARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_EstatusProducto] PRIMARY KEY CLUSTERED ([EstatusProductoID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusProducto_EstatusProductoClave]
    ON [dbo].[SistemaEstatusProducto]([EstatusProductoClave] ASC);

