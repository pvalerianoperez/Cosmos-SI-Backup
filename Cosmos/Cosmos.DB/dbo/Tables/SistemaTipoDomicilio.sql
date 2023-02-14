CREATE TABLE [dbo].[SistemaTipoDomicilio] (
    [SistemaTipoDomicilioID]    INT          IDENTITY (1, 1) NOT NULL,
    [SistemaTipoDomicilioClave] VARCHAR (10) NOT NULL,
    [Nombre]                    VARCHAR (30) NOT NULL,
    [NombreCorto]               VARCHAR (10) NOT NULL,
    [Estatus]                   BIT          NOT NULL,
    CONSTRAINT [PK_SistemaTipoDomicilio] PRIMARY KEY CLUSTERED ([SistemaTipoDomicilioID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoDomicilio_SistemaTipoDomicilioClave]
    ON [dbo].[SistemaTipoDomicilio]([SistemaTipoDomicilioClave] ASC);

