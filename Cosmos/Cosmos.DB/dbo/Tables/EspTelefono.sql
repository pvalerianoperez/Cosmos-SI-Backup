CREATE TABLE [dbo].[EspTelefono] (
    [EspTelefonoID]            INT           IDENTITY (1, 1) NOT NULL,
    [ClaveTelefonicaPais]      VARCHAR (3)   NOT NULL,
    [NumeroTelefonico]         VARCHAR (10)  NOT NULL,
    [SistemaEstatusTelefonoID] INT           CONSTRAINT [DF_Telefono_EstatusTelefonoID] DEFAULT ((1)) NOT NULL,
    [CfgTipoTelefonoID]        INT           NOT NULL,
    [Comentario]               VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_EspTelefono] PRIMARY KEY CLUSTERED ([EspTelefonoID] ASC),
    CONSTRAINT [FK_Telefono_CfgTipoTelefono] FOREIGN KEY ([CfgTipoTelefonoID]) REFERENCES [dbo].[CfgTipoTelefono] ([CfgTipoTelefonoID]),
    CONSTRAINT [FK_Telefono_SistemaEstatusTelefono] FOREIGN KEY ([SistemaEstatusTelefonoID]) REFERENCES [dbo].[SistemaEstatusTelefono] ([EstatusTelefonoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Telefono_LadaPais_NumeroTelefonico]
    ON [dbo].[EspTelefono]([ClaveTelefonicaPais] ASC, [NumeroTelefonico] ASC);

