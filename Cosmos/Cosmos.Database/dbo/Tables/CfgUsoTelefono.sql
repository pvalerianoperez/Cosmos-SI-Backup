CREATE TABLE [dbo].[CfgUsoTelefono] (
    [CfgUsoTelefonoID]     INT          IDENTITY (1, 1) NOT NULL,
    [CfgUsoTelefonoClave]  VARCHAR (10) NOT NULL,
    [Nombre]               VARCHAR (40) NOT NULL,
    [NombreCorto]          VARCHAR (15) NOT NULL,
    [Activo]               BIT          NOT NULL,
    [SistemaUsoTelefonoID] INT          NOT NULL,
    CONSTRAINT [PK_CfgUsoTelefonoID] PRIMARY KEY CLUSTERED ([CfgUsoTelefonoID] ASC),
    CONSTRAINT [FK_CfgUsoTelefono_SistemaUsoTelefono] FOREIGN KEY ([SistemaUsoTelefonoID]) REFERENCES [dbo].[SistemaUsoTelefono] ([SistemaUsoTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgUsoTelefono_CfgUsoTelefonoClave]
    ON [dbo].[CfgUsoTelefono]([CfgUsoTelefonoClave] ASC);

