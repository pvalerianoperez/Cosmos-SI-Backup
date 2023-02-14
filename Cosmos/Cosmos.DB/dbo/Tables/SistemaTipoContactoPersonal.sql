CREATE TABLE [dbo].[SistemaTipoContactoPersonal] (
    [TipoContactoPersonalID]    INT          IDENTITY (1, 1) NOT NULL,
    [TipoContactoPersonalClave] VARCHAR (4)  CONSTRAINT [DF_SistemaTipoContactoPersonal_TipoContactoPersonalClave] DEFAULT ('') NOT NULL,
    [Nombre]                    VARCHAR (30) NOT NULL,
    [NombreCorto]               VARCHAR (10) NOT NULL,
    [Conyuge]                   BIT          NOT NULL,
    CONSTRAINT [PK_SistemaPersonalTipoContacto] PRIMARY KEY CLUSTERED ([TipoContactoPersonalID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SistemaTipoContactoPersonal_TipoContactoPersonalClave]
    ON [dbo].[SistemaTipoContactoPersonal]([TipoContactoPersonalClave] ASC);

