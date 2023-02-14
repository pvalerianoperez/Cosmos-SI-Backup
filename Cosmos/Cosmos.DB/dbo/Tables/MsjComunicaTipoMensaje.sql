CREATE TABLE [dbo].[MsjComunicaTipoMensaje] (
    [TipoMensajeID] INT           IDENTITY (1, 1) NOT NULL,
    [TipoClave]     NVARCHAR (6)  NOT NULL,
    [Nombre]        NVARCHAR (50) NOT NULL,
    [NombreCorto]   NVARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([TipoMensajeID] ASC),
    CONSTRAINT [AK_MsjComunicaTipoMensaje_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_MsjComunicaTipoMensaje_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC),
    CONSTRAINT [AK_MsjComunicaTipoMensaje_TipoClave] UNIQUE NONCLUSTERED ([TipoClave] ASC)
);

