CREATE TABLE [dbo].[MsjComunicaTipoMensaje]
(
	[TipoMensajeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TipoClave] NVARCHAR(6) NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [NombreCorto] NVARCHAR(15) NOT NULL,
    CONSTRAINT [AK_MsjComunicaTipoMensaje_TipoClave] UNIQUE ([TipoClave]),
    CONSTRAINT [AK_MsjComunicaTipoMensaje_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_MsjComunicaTipoMensaje_NombreCorto] UNIQUE ([NombreCorto])
)
