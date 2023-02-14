CREATE TABLE [dbo].[CfgTipoTelefono] (
    [CfgTipoTelefonoID]     INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoTelefonoClave]  VARCHAR (10) NOT NULL,
    [Nombre]                VARCHAR (40) NOT NULL,
    [NombreCorto]           VARCHAR (15) NOT NULL,
    [Activo]                BIT          NOT NULL,
    [SistemaTipoTelefonoID] INT          NOT NULL,
    CONSTRAINT [PK_CfgTipoTelefonoID] PRIMARY KEY CLUSTERED ([CfgTipoTelefonoID] ASC),
    CONSTRAINT [FK_CfgTipoTelefono_SistemaTipoTelefono] FOREIGN KEY ([SistemaTipoTelefonoID]) REFERENCES [dbo].[SistemaTipoTelefono] ([SistemaTipoTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgTipoTelefono_CfgTipoTelefonoClave]
    ON [dbo].[CfgTipoTelefono]([CfgTipoTelefonoClave] ASC);

