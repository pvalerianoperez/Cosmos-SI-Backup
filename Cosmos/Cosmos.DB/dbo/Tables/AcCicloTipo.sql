CREATE TABLE [dbo].[AcCicloTipo] (
    [CicloTipoID]    INT          IDENTITY (1, 1) NOT NULL,
    [CicloTipoClave] VARCHAR (6)  NULL,
    [Nombre]         VARCHAR (80) NOT NULL,
    [NombreCorto]    VARCHAR (15) NULL,
    CONSTRAINT [PK_AcCicloTipo] PRIMARY KEY CLUSTERED ([CicloTipoID] ASC)
);

