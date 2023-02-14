CREATE TABLE [dbo].[MsjChatTipoMensaje] (
    [TipoMensajeID] INT          IDENTITY (1, 1) NOT NULL,
    [TipoNombre]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TipoMensajeID] ASC)
);



