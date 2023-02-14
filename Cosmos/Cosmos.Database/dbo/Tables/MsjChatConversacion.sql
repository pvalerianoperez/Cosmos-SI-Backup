CREATE TABLE [dbo].[MsjChatConversacion] (
    [ConversacionID] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]         NVARCHAR (50) NOT NULL,
    [Borrada]        DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([ConversacionID] ASC)
);

