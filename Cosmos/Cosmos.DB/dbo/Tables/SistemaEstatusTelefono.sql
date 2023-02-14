CREATE TABLE [dbo].[SistemaEstatusTelefono] (
    [EstatusTelefonoID]    INT          IDENTITY (1, 1) NOT NULL,
    [EstatusTelefonoClave] VARCHAR (4)  NOT NULL,
    [Nombre]               VARCHAR (25) NOT NULL,
    [NombreCorto]          VARCHAR (8)  NOT NULL,
    CONSTRAINT [PK_EstatusTelefono] PRIMARY KEY CLUSTERED ([EstatusTelefonoID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaEstatusTelefono_EstatusTelefonoClave]
    ON [dbo].[SistemaEstatusTelefono]([EstatusTelefonoClave] ASC);

