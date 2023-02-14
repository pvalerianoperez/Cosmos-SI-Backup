CREATE TABLE [dbo].[AcCicloTipo] (
    [CicloTipoID]    INT          NOT NULL IDENTITY,
    [CicloTipoClave] VARCHAR (6)  NULL,
    [Nombre]         VARCHAR (80) NOT NULL,
    [NombreCorto]    VARCHAR (15) NULL,
    CONSTRAINT [PK_AcCicloTipo] PRIMARY KEY CLUSTERED ([CicloTipoID] ASC)
);

