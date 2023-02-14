CREATE TABLE [dbo].[SistemaTipoTelefono] (
    [SistemaTipoTelefonoID]    INT          IDENTITY (1, 1) NOT NULL,
    [SistemaTipoTelefonoClave] VARCHAR (10) NOT NULL,
    [Nombre]                   VARCHAR (30) NOT NULL,
    [NombreCorto]              VARCHAR (10) NOT NULL,
    [Estatus]                  BIT          NOT NULL,
    CONSTRAINT [PK_SistemaTipoTelefono] PRIMARY KEY CLUSTERED ([SistemaTipoTelefonoID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoTelefono_TipoTelefonoClave]
    ON [dbo].[SistemaTipoTelefono]([SistemaTipoTelefonoClave] ASC);

