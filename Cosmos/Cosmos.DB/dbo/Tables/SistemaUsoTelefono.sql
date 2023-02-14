CREATE TABLE [dbo].[SistemaUsoTelefono] (
    [SistemaUsoTelefonoID]    INT          IDENTITY (1, 1) NOT NULL,
    [SistemaUsoTelefonoClave] VARCHAR (10) NOT NULL,
    [Nombre]                  VARCHAR (30) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    [Estatus]                 BIT          NOT NULL,
    CONSTRAINT [PK_SistemaUsoTelefonoID] PRIMARY KEY CLUSTERED ([SistemaUsoTelefonoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaUsoTelefono_SistemaUsoTelefonoClave]
    ON [dbo].[SistemaUsoTelefono]([SistemaUsoTelefonoClave] ASC);

