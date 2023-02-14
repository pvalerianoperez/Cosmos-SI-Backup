CREATE TABLE [dbo].[SistemaMetodoCosteo] (
    [MetodoCosteoID]    INT          IDENTITY (1, 1) NOT NULL,
    [MetodoCosteoClave] VARCHAR (4)  NOT NULL,
    [Nombre]            VARCHAR (25) NOT NULL,
    [NombreCorto]       VARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_MetodoCosteo] PRIMARY KEY CLUSTERED ([MetodoCosteoID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaMetodoCosteo]
    ON [dbo].[SistemaMetodoCosteo]([MetodoCosteoClave] ASC);



