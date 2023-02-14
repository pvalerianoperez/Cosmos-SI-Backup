CREATE TABLE [dbo].[CfgTipoContactoPersonal] (
    [CfgTipoContactoPersonalID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoContactoPersonalClave] VARCHAR (4)  NOT NULL,
    [Nombre]                       VARCHAR (50) NOT NULL,
    [NombreCorto]                  VARCHAR (20) NOT NULL,
    CONSTRAINT [PK__CfgContactoPersonal] PRIMARY KEY CLUSTERED ([CfgTipoContactoPersonalID] ASC)
);

