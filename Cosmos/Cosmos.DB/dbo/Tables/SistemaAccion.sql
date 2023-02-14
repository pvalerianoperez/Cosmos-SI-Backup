CREATE TABLE [dbo].[SistemaAccion] (
    [AccionID]    INT           IDENTITY (1, 1) NOT NULL,
    [AccionClave] NVARCHAR (30) NOT NULL,
    [Nombre]      NVARCHAR (50) NOT NULL,
    [NombreCorto] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_SistemaAccion] PRIMARY KEY CLUSTERED ([AccionID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaAccionClave]
    ON [dbo].[SistemaAccion]([AccionClave] ASC);

